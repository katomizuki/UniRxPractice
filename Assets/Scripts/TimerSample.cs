using System;
using UnityEngine;
using UniRx;
using System.Threading;

public class TimerSample : MonoBehaviour
{
    private void Start()
    {
        // MainThreadを指定。一秒後に実行することをTimerOperatorで指定。
        Observable.Timer(TimeSpan.FromSeconds(1), Scheduler.MainThread)
            .Subscribe(x =>
            {
                Debug.Log(x);
            })
            .AddTo(this);

        // 未指定の場合はMainThreadSchedulerと同じになる

        Observable.Timer(TimeSpan.FromSeconds(1))
            .Subscribe(x => Debug.Log("1秒経過しました"))
            .AddTo(this);

        // MainThreadEndOfFrame指定の時
        Observable.Timer(TimeSpan.FromSeconds(1), Scheduler.MainThreadEndOfFrame)
            .Subscribe(x =>
            {
                Debug.Log(x);
            })
            .AddTo(this);

        // CurrentThreadを指定すると同じスレッドで実行される
        new Thread(() =>
        {
            Observable.Timer(TimeSpan.FromSeconds(1), Scheduler.CurrentThread)
            .Subscribe(x =>
            {
                Debug.Log(x);
            })
            .AddTo(this);
        }).Start();

    }


}
