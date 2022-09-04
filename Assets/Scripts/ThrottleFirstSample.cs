using UniRx;
using UnityEngine;
using System;
using UniRx.Triggers;

public class ThrottleFirstSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.UpdateAsObservable()
            .Where(_ => Input.GetKey(KeyCode.Z))
            .ThrottleFirst(TimeSpan.FromSeconds(1))
            .Subscribe(_ => Debug.Log("Pressed z Key"));
    }

}
