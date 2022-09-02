using UniRx;
using UnityEngine;
using System;
using System.Collections;

public class AsyncSubject : MonoBehaviour
{
    private readonly AsyncSubject<Texture> _playerTextureAsyncSubject = new AsyncSubject<Texture>();
    // プレイヤのテクスチャ情報を担うAsyncSubject
    public IObservable<Texture> PlayerTextureAsync => _playerTextureAsyncSubject;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(LoadTexture());    
    }

    private IEnumerator LoadTexture()
    {
        // プレイヤのテクスチャを非同期で読み込み
        var resources = Resources.LoadAsync<Texture>("Textures/player");
        yield return resources;

        // 読み込み完了したらAsyncSubject->Completed()が呼ばれた時の最新のやつの流す

        _playerTextureAsyncSubject.OnNext(resources.asset as Texture);
        _playerTextureAsyncSubject.OnCompleted();







    }

}
