using UniRx;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Observable.Range(1, 10)
            .Skip(3)
            .Subscribe(x => Debug.Log(x));
    }
}
