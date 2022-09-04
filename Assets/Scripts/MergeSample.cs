using UniRx;
using UnityEngine;

public class MergeSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Schedulerを指定して1フレームに一個ずつ値を発行する
        var s1 = Observable.Range(10, 3, Scheduler.MainThread);
        var s2 = Observable.Range(20, 3, Scheduler.MainThread);

        // 現在のフレーム数と出力結果をペアにして表示

        s1.Merge(s2)
            .Subscribe(x => {
                Debug.Log(x);
            });
    }
}
