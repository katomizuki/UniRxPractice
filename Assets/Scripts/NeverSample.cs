using UniRx;
using UnityEngine;

public class NeverSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.Never<int>()
            .Subscribe(x => Debug.Log("OnNext"), ex => Debug.LogError("Error"), () => Debug.Log("Completed"));


    }
}
