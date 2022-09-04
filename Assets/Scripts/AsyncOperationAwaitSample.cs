using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;


public class AsyncOperationAwaitSample : MonoBehaviour
{
    

    // Start is called before the first frame update
    private async UniTaskVoid  Start()
    {
        var token = this.GetCancellationTokenOnDestroy();

        try
        {
            // UnityWebRequesAsyncOperationのawait
            var urw = UnityWebRequest.Get("https://unity.com/ja");

            // CancellationTokenを設定しておく
            await urw.SendWebRequest().WithCancellation(token);

            // ToUniTaskを使うと
            // 現在の進行状況の取得とCancellationTokenの指定が同時にできる
            var uwr2 = UnityWebRequest.Get("https://");
            await uwr2.SendWebRequest()
                .ToUniTask(Progress.Create<float>(x => Debug.Log(x)), cancellationToken: token);
        } catch
        {
            Debug.LogError("errro");
        }

        await Resources.LoadAsync<Texture>("Playerhealth");

        // AsyncOperationのAwait
        await SceneManager.LoadSceneAsync("NextScene");
    }

}
