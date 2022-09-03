using System.Collections;
using UnityEngine;
using UniRx;

public class FromCorotineSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // こルーチンの終了でObservableで待ち受ける
        Observable.FromCoroutine(WaitingCoroutine, publishEveryYield: false)
            .Subscribe(
            _ => Debug.Log("OnNext"),
            () => Debug.Log("OnCompleted"))
            .AddTo(this);
    }

    // 三秒待機
    private IEnumerator WaitingCoroutine()
    {
        yield return new WaitForSeconds(3);


    }
}
