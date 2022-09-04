using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine.UI;
using UnityEngine;

public class PageFeed : MonoBehaviour
{
    // ページ送りのサンプル
    // 複数設定したテクスチャをボタンをクリックされるたびに順番にRawImageに表示していく
    [SerializeField]
    private Texture[] textures;

    [SerializeField]
    private Button button;

    [SerializeField]
    private RawImage rawImage;


    void Start()
    {
        var token = this.GetCancellationTokenOnDestroy();

        InitAsync(token);
    }

    private async UniTaskVoid InitAsync(CancellationToken token)
    {
        // ugui 　ButtonのクリックイベントAsyncHandler
        using(var clickEventHandler = button.GetAsyncClickEventHandler(token))
        {
            for (int  i = 0; i < textures.Length; i++)
            {
                rawImage.texture = textures[i];
                await clickEventHandler.OnClickAsync();
            }
        }
    }




    
}
