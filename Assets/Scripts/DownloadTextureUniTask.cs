using System;
using System.Threading;
using UnityEngine;
using UniRx;
using UnityEngine.Networking;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

public class DownloadTextureUniTask : MonoBehaviour
{
    [SerializeField]
    private RawImage rawImage;
    // Start is called before the first frame update
    void Start()
    {
        var token = this.GetCancellationTokenOnDestroy();

        // テクスチャのセットアップを実行
        SetupTextureAsync(token).Forget();
    }

    private async UniTaskVoid SetupTextureAsync(CancellationToken token)
    {
        try
        {
            var uri = "";
            var observable = Observable.Defer(() =>
            {
                return GetTextureAsync(uri, token).ToObservable();
            })
            .Retry(3);
        }
        catch (Exception e) when (!(e is OperationCanceledException))
        {
            Debug.LogError(e);
        }
    }

    private async UniTask<Texture> GetTextureAsync(string uri, CancellationToken token)
    {
        using(var uwr = UnityWebRequestTexture.GetTexture(uri))
        {
            await uwr.SendWebRequest().WithCancellation(token);
            return ((DownloadHandlerTexture) uwr.downloadHandler).texture;
        }
    }

}
