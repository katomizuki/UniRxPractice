using UniRx;
using UnityEngine;

public class EmptySample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.Empty<int>()
            .Subscribe(
                x => Debug.Log("エラー"),
                Exception => Debug.LogError("エラー"),
                () => Debug.Log("OnCompleted")
                );
    }

}
