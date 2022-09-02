using UniRx;
using UnityEngine;

public class ReplaySubjectSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var subject = new ReplaySubject<int>(bufferSize: 3);

        // メッセージを発行
        for (int i = 0; i < 10; i++)
        {
            subject.OnNext(i);
        }

        // OnCompleted メッセージもキャッシュできる
        subject.OnCompleted();

        // OnError メッセージもキャッシュできる
        subject.Subscribe(
            x => Debug.Log("OnNext"),
            ex => Debug.LogError("OnError"),
            () => Debug.Log("OnCompleted")
            );

        subject.Dispose();
    }

}
