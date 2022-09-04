using UniRx;
using UnityEngine;

public class ZipSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var s1 = new[] { "a", "b", "c" }.ToObservable();
        var s2 = Observable.Range(0, 3).Select(x => x);

        s1.Zip(s2, (x1, x2) => $"{x1}{x2}")
            .Subscribe(x => Debug.Log(x));


    }

}
