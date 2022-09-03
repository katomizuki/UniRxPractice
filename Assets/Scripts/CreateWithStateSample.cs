using System;
using UniRx;
using UnityEngine;

public class CreateWithStateSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CreateCountObservable(10)
            .Subscribe(x => Debug.Log(x));

    }

    private IObservable<int> CreateCountObservable(int count)
    {
        // countが0以下の場合はOnCompletedメッセージのみを返す
        if (count <= 0) return Observable.Empty<int>();

        return Observable.CreateWithState<int, int>(state: count,
            subscribe: (maxCount, observer) =>
        {
            // masCountにStateで指定した値が入ってくる
            for (int i = 0; i < maxCount; i++)
            {
                observer.OnNext(i);
            }
            observer.OnCompleted();
            return Disposable.Empty;
        });
    }
}
