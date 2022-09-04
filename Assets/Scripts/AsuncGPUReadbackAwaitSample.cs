using System;
using System.IO;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine.Rendering;

public class AsuncGPUReadbackAwaitSample : MonoBehaviour
{
    [SerializeField]
    private Camera camera;

    private RenderTexture renderTexture;

    private async UniTaskVoid Start()
    {
        var token = this.GetCancellationTokenOnDestroy();

        // カメラの初期化
        InitCamera();
    }


    private void InitCamera()
    {
        renderTexture = new RenderTexture(width: 512, height: 512, depth: 24, format: RenderTextureFormat.ARGB32, readWrite: RenderTextureReadWrite.Default);
        camera.targetTexture = renderTexture;
        camera.enabled = false;

    }


    // カメラ映像をスクリーンショットとして保存する

    [Obsolete]
    private async UniTask TakeScreenShotAsync(CancellationToken token)
    {
        camera.enabled = true;
        await UniTask.NextFrame(cancellationToken: token);

        camera.enabled = false;

        // GPUからのデータ情報取得を待つ
        // AsyncGPUReadbackRequest型が戻ってくる
        var req = await AsyncGPUReadback.Request(renderTexture, 0)
            .WithCancellation(token);

        var rawByteArray = req.GetData<byte>();

        // renderTextureの内容をPNGに変換
        var png = ImageConversion.EncodeNativeArrayToPNG(rawByteArray, renderTexture.graphicsFormat, (uint)renderTexture.width, (uint)renderTexture.height);

        var bytes = png.ToArray();
        png.Dispose();

        await UniTask.Run(action: () => File.WriteAllBytes("screenshot.png", bytes));
    }
   
}
