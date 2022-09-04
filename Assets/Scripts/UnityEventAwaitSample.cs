using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine.Events;
using UnityEngine;

public class UnityEventAwaitSample : MonoBehaviour
{
    public UnityEvent UnityEvent;
    // Start is called before the first frame update
    void Start()
    {
        var token = this.GetCancellationTokenOnDestroy();
        MoveAsync(UnityEvent, token).Forget();
    }


    private async UniTaskVoid MoveAsync(UnityEvent unityEvent, CancellationToken token)
    {
        using(var asyncHandler = unityEvent.GetAsyncEventHandler(token))
        {
            await asyncHandler.OnInvokeAsync();
            Debug.Log("Event Receive");
        }
    }
}
