using UniRx;
using UnityEngine;

public class SubjectSample : MonoBehaviour
{
    private void Start()
    {
        var subject = new Subject<int>();

        // メッセージを発行
        subject.OnNext(1);

        // 購読開始
        subject.Subscribe(
            x => Debug.Log("OnNext"),
            ex => Debug.LogError("OnError"),
            () => Debug.Log("OnCompleted")
            );

        // メッセージ変換
        subject.OnNext(2);
        subject.OnNext(3);

        subject.OnCompleted();

        // Disposeを忘れずに
        subject.Dispose();
    }
}
