using System;
using System.Collections;
using UniRx;
using UnityEngine;

public class CountDownEventProvider : MonoBehaviour
{
    [SerializeField]
    private int _countSeconds = 10;

    // Subjectのインスタンス
    public Subject<int> _subject;

    public IObservable<int> CountDownObservable => _subject;

    private void Awake()
    {
        _subject = new Subject<int>();

        // カウントダウンするコルーチン
        StartCoroutine(CountCoroutine());
    }

    private IEnumerator CountCoroutine()
    {
        var current = _countSeconds;
        while( current > 0)
        {
            // 現在の値を発行する
            _subject.OnNext(current);
            current--;
            yield return new WaitForSeconds(1.0f);
        }

        // 最後に0を取ってOnCompletedメッセージを発行する
        _subject.OnNext(0);
        _subject.OnCompleted();
    }

    private void OnDestroy()
    {
        // GameObjectが破棄されたらSubjectも解放
        _subject.Dispose();
    }
}
