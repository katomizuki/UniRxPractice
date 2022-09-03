using UniRx;
using UnityEngine;

public class ObservableRangeSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.Range(start: 0, count: 5)
            .Subscribe(x => Debug.Log("OnNext"),
            ex => Debug.LogError("OnCompelted"),
            () => Debug.Log("Oncompleted"));
    }

}
