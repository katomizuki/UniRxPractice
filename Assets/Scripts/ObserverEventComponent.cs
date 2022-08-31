using System;
using UnityEngine;

public class ObserverEventComponent : MonoBehaviour
{
    [SerializeField]
    private CountDownEventProvider countDownEventProvider;

    // Observerのインスタンス
    private PrintLogObserver<int> _printLogObserver;

    private IDisposable _disposable;

    private void Start()
    {
        // PrintLogObserverインスタンスを作成
        _printLogObserver = new PrintLogObserver<int>();

        // SubjectのSubscribeを呼び出してObserverを登録する
        _disposable = countDownEventProvider
            .CountDownObservable
            .Subscribe(_printLogObserver);
    }

    private void OnDestroy()
    {
        _disposable.Dispose();
    }
}
