using UnityEngine;
using UniRx;

public class SingleSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.Range(1, 10)
            .Single(x => x % 2 == 0)
            .Subscribe(
                x => Debug.Log(x),
                ex => Debug.LogError(ex),
                () => Debug.Log("Completed"));


    }

}
