using UniRx;
using UnityEngine;
using System.Collections;
using Cysharp.Threading.Tasks;

public class CoroutineAwaiterSample : MonoBehaviour
{
 
    private async UniTaskVoid Start()
    {
        // こルーチンにawaitをつけるだけで自動的に、こルーチンが起動して待ち受ける
        await MoveCoroutine(Vector3.forward * 1.0f, 2);
        await MoveCoroutine(Vector3.right * 2.0f, 1);
        await MoveCoroutine(Vector3.back * 2f, 1);
    }

    // 指定した速度で指定した秒数を移動するコルーチン
    private IEnumerator MoveCoroutine(Vector3 velocity, float seconds)
    {
        var start = Time.time;

        while((Time.time - start) < seconds)
        {
            transform.position += velocity * Time.deltaTime;
            yield return null;
        }
    }



}
