using UniRx;
using UnityEngine;
using System;

public class TimerSample1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // ①秒後に発火するObservable 指定した時間に発火するようにする。
        var timer = Observable.Timer(dueTime: TimeSpan.FromSeconds(1));

        timer.Subscribe(x => {
            Debug.Log("OnNext");
            Debug.Log("OnNext");
        }, () => Debug.Log("OnCompleted"));


    }

}
