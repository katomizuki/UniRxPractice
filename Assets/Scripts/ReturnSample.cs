using UniRx;
using UnityEngine;

public class ReturnSample : MonoBehaviour
{
    private void Start()
    {
        // Returnで生成する
        Observable.Return(100)
            .Subscribe(
            x => Debug.Log("OnNext"),
            ex => Debug.Log("OnCompleted"),
            () => Debug.Log("Completed")
            );

    }
}
