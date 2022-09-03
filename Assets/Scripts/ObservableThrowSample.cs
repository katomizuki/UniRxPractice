using UniRx;
using UnityEngine;

public class ObservableThrowSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.Throw<int>(new System.Exception("エラー"))
            .Subscribe(
                x => Debug.Log(""),
                ex => Debug.LogError(""),
                () => Debug.Log("エラー"));


    }

}
