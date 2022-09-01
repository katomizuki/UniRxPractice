using System;
using UnityEngine;
using UniRx;

public class MessageSample : MonoBehaviour
{
    [SerializeField]
    private float _countTimeSeconds = 30f;

// 時間切れを通知するオブジェクト
    public IObservable<Unit> OnTimeUpAsyncObject => _onTimeUpAsyncSubject;

    // AsyncObject
    private readonly AsyncSubject<Unit> _onTimeUpAsyncSubject = new AsyncSubject<Unit>();

    private IDisposable _disposable;

    private void Start() 
    {
        _disposable = Observable.Timer(TimeSpan.FromSeconds(_countTimeSeconds))
        .Subscribe(_ =>  {
            /// Timerが発火したらunit型のメッセージを送る
            _onTimeUpAsyncSubject.OnNext(Unit.Default);
            _onTimeUpAsyncSubject.OnCompleted();
        });
    }

    private void OnDestroy()
    {
        // Observableがまだ動いていたら
        _disposable.Dispose();
        _onTimeUpAsyncSubject.Dispose();
    }
}
