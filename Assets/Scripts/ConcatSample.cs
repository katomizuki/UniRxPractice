using UniRx;
using UnityEngine;

public class ConcatSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var s1 = Observable.Range(0, 3);
        var s2 = Observable.Range(0, 4);

        s1.Concat(s2)
            .Subscribe(x => Debug.Log(x));
    }
}
