using UniRx;
using UnityEngine;

public class ReactivePropertySample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var health = new ReactiveProperty<int>(100);


        health.Subscribe(
            x => Debug.Log("アイウエオ"),
            () => Debug.Log("OnCompleted"));

        /// Valueに通知すると発火
        ///
        health.Value = 50;

        health.Dispose();

    }

}
