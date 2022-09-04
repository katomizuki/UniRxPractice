using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;
using System;
using UnityEngine.Networking;


public class TwiceAwaitSample : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        // CancellationTokenを生成
        var token = this.GetCancellationTokenOnDestroy();
        
    }

    private async UniTaskVoid DoAsync(CancellationToken token)
    {
        try
        {
            // HTTP通信を行いキャッシュする
            var uniTask = GetAsync("https://unity.com/ja", token);

            // 一回めのawaitは問題ない 実際に実行する
            await uniTask;
        } catch
        {
            Debug.Log("error");
        }
        
    }

    // HTTP Getを行う
    private async UniTask<string> GetAsync(string uri, CancellationToken token)
    {
        using (var uwr = UnityWebRequest.Get(uri))
        {
            await uwr.SendWebRequest().WithCancellation(token);
            return uwr.downloadHandler.text;
        }
    }
}
