using UnityEngine;
using System;
using UniRx;

public class ObserverEventComponent2 : MonoBehaviour
{
    [SerializeField]
    private CountDownEventProvider countDownEventProvider;

    // Observerのインスタンス
    private PrintLogObserver<int> printLogObserver;

    private IDisposable disposable;



    private void Start()
    {
        // SubjectのSubscribeを呼び出してobserverを登録する

        disposable = countDownEventProvider
            .CountDownObservable
            .Subscribe(
            x => Debug.Log(x),
            ex => Debug.Log(ex),
            () => Debug.Log("On Completed")
            );
    }
}
