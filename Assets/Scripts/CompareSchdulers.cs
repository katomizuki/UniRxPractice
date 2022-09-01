using UniRx;
using System;
using UnityEngine;

public class CompareSchdulers : MonoBehaviour
{
    private void Start()
    {
        // Unityのコル-チンを用いて三秒計測してくれる（メインスレッドをブロックしない）
        Observable
            .Timer(TimeSpan.FromSeconds(3), Scheduler.MainThread)
            .Subscribe()
            .AddTo(this);

        // メインスレッドをThread .Sleepして三秒計測 メインスレッドを妨害する

        Observable.
            Timer(TimeSpan.FromSeconds(3), Scheduler.CurrentThread)
            .Subscribe()
            .AddTo(this);

    }
}
