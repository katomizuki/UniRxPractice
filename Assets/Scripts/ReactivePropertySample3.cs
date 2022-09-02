using UniRx;
using UnityEngine;

public class ReactivePropertySample3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var health = new ReactiveProperty<int>(100);

        // SkipLatestValueで現在の値を無視できる。
        health.SkipLatestValueOnSubscribe()
            .Subscribe(x => Debug.Log("通知されたよ"));

        health.Dispose();
    }
}
