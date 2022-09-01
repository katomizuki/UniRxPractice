using UniRx;
using UnityEngine;

public class AddSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.IntervalFrame(5)
            .Subscribe(_ => Debug.Log("Do"))
            // このGameObjectのOnDestroyに連動して自動でDisposeする
            .AddTo(this);
    }

}
