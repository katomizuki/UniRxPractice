using UniRx;
using UnityEngine;

public class TakeSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var array = new[] { 1, 3, 1, 1 };
        array.ToObservable()
            .Take(1)
            .Subscribe(
            x => Debug.Log(x),
            ex => Debug.LogError(ex),
            () => Debug.Log("Completed")
            );
    }

}
