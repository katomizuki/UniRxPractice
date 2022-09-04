using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class UniTaskVoidSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // UniTaskVoidは実行完了を待機できない
        // そのため実行後、そのまま待機したい時に利用できる
        DoAsync().Forget();
    }

    private async UniTaskVoid DoAsync()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(1));
        Destroy(gameObject);
    }

}


public class UniTaskVoidSample2 : MonoBehaviour
{

    private async UniTaskVoid Start()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(10));
        Destroy(gameObject);
    }
}
