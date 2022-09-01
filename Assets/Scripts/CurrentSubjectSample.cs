using System.Threading;
using System.Threading.Tasks;
using UniRx;
using UnityEngine;

public class CurrentSubjectSample : MonoBehaviour
{
   private void Start()
    {
        Debug.Log("Unity main Thread Id");

        var subject = new Subject<Unit>();

        subject.AddTo(this);

        subject
            // OnNext メッセージを現行スレッドで処理する
            // そのまま素通りするのと変わらない
            .ObserveOn(Scheduler.Immediate)
            .Subscribe(_ =>
           {
               Debug.Log("Debug Log");
           });

        //  メインスレッドにてOnNextを実行

        subject.OnNext(Unit.Default);
        Task.Run(() => subject.OnNext(Unit.Default));

        subject.OnCompleted();
    }
}
