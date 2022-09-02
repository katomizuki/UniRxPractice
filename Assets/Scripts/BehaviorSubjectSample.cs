using UniRx;
using UnityEngine;

public class BehaviorSubjectSample : MonoBehaviour
{
    private void Start()
    {
        // BehaviorSubjectの定義に必ず必要
        var behaviorSubject = new BehaviorSubject<int>(1);

        // メッセージ変換

        behaviorSubject.OnNext(1);

        // 購読開始
        behaviorSubject.Subscribe(
            x => Debug.Log(x),
            ex => Debug.Log(ex),
            () => Debug.Log("Completed")
            );

        behaviorSubject.OnNext(2);



        behaviorSubject.OnNext(3);
        behaviorSubject.OnCompleted();

        behaviorSubject.Dispose();


    }
}
