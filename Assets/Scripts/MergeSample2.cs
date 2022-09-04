using UniRx;
using UnityEngine;
using System;
public class MergeSample2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        IObservable<IObservable<int>> streams = Observable
            .Range(1, 3, Scheduler.Immediate)
            .Select(x => {
                return Observable.Range(x * 100, 3, Scheduler.Immediate);
            });

        streams.
            Merge()
            .Subscribe(x => Debug.Log(x));
    }
}
