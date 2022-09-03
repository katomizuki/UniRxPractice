using UniRx.Triggers;
using UniRx;
using UnityEngine;

public class ObserveStateMachineSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 対象のAnimator
        var animator = GetComponent<Animator>();

        // triggerの取得
        var trigger = animator.GetBehaviour<ObservableStateMachineTrigger>();

        // AttackState
        var attckStart = trigger.OnStateEnterAsObservable().Where(x => x.StateInfo.IsName("Attack"));

        // AttackStateから遷移する通知
        var attackEnd = trigger.OnStateExitAsObservable().Where(x => x.StateInfo.IsName("Attack"));

        // AttackStateにいる間、毎フレーム処理を実行する

        this.UpdateAsObservable()
            .SkipUntil(attckStart)
            .TakeUntil(attackEnd)
            .RepeatUntilDestroy(this)
            .Subscribe(_ => { Debug.Log("Attack"); })
            .AddTo(this);
    }
}
