using UnityEngine;
using UniRx;

public class ReactivePropertySample2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var health = new ReactiveProperty<int>(100);

        health.Subscribe(x => Debug.Log("通知された"),
            () => Debug.Log("OnCompleted"));

        // 値が変わらなければ通知は起きない
        health.Value = 100;

        health.SetValueAndForceNotify(100);
        // 強制的に通知を飛ばす

        health.Dispose();
    }
}
