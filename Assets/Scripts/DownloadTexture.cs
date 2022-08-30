using System.Collections;
using UnityEngine;
using System;
using UnityEngine.Networking;
using UnityEngine.UI;
using UniRx;

public class DownloadTexture : MonoBehaviour
{
    [SerializeField]
    private RawImage _rawImage;

    void Start()
    {
        var uri = "";

        GetTextureAsync(uri)
            .OnErrorRetry(
                onError: (Exception _) => { },
                retryCount: 3)
            .Subscribe(
                result => { _rawImage.texture = result; },
                error => { Debug.LogError(error); }
            ).AddTo(this);
    }

    private IObservable<Texture> GetTextureAsync(string uri)
    {
        return Observable.FromCoroutine<Texture>(observer =>
            {
                return GetTextureCorutine(observer, uri);
            });
    }

    private IEnumerator GetTextureCorutine(IObserver<Texture> observer, string uri)
    {
        using(var uwr = UnityWebRequestTexture.GetTexture(uri))
        {
            yield return uwr.SendWebRequest();

            if(uwr.isNetworkError || uwr.isHttpError)
            {
                observer.OnError(new Exception(uwr.error));
                yield break;
            }

            var result = ((DownloadHandlerTexture)uwr.downloadHandler).texture;
            observer.OnNext(result);
            observer.OnCompleted();
        }
    }
}
