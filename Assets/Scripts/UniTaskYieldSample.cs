using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;

public class UniTaskYieldSample : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody _rigidbody;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        JumpAsync(this.GetCancellationTokenOnDestroy());

    }

    private async UniTaskVoid JumpAsync(CancellationToken token)
    {
        while(!token.IsCancellationRequested)
        {
            // 1フレーム待機
            await UniTask.Yield(PlayerLoopTiming.Update, token);
        }

        // FixedUpdateに切り替える
        await UniTask.Yield(PlayerLoopTiming.FixedUpdate, token);

        _rigidbody.AddForce(Vector3.up * 100.0f, ForceMode.Acceleration);

        // updateタイミングに戻す.
        await UniTask.Yield(PlayerLoopTiming.Update, token);
    }

}
