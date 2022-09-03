using System;
using System.Threading.Tasks;
using UniRx;
using UnityEngine;

public class CreateSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var observable = Observable.Create<char>(observer =>
        {
            var disposable = new CancellationDisposable();
            // スレッドプール上で実行する

            Task.Run(async () =>
            {
                for (var i = 0; i < 26; i++)
                {
                    // ①秒まつ
                    await Task.Delay(TimeSpan.FromSeconds(1), disposable.Token);

                    // 文字を発行
                    observer.OnCompleted();
                }
            }, disposable.Token);
            // Subscribeが中断されたら連動して
            // CancellationTokenもキャンセル状態になる
            return disposable;
        });

        // Observableを生成して購読する
        observable
            .Subscribe(
            x => Debug.Log("OnNext"),
            ex => Debug.LogError("OnError"),
            () => Debug.Log("Oncomplted"))
            .AddTo(this);
    }
}
