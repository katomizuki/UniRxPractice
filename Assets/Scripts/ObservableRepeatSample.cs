using UnityEngine;
using UniRx;


public class ObservableRepeatSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.Repeat(value: "yes", repeatCount: 4)
            .Subscribe(x => Debug.Log("OnNext"), ex => Debug.LogError("Error"), () => Debug.Log("OnCompleted"));


    }
}
