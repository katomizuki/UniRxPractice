using UniRx;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System;

public class FromEventSample : MonoBehaviour
{
    public sealed class MyEventArgs: EventArgs
    {
        public int MyProperty { get; set; }
    }
    // MyEventArgsを扱うイベントハンドラ
    event EventHandler<MyEventArgs> _onEvent;

    // int型を引数にとるAction
    //event Action<int> _callbackAction;

    // uGuiのボタン
    [SerializeField]
    private Button _uiButton;

    private readonly CompositeDisposable disposables = new CompositeDisposable();

    // Start is called before the first frame update
    void Start()
    {
        // FromEventPatternを使うケース
        // (sender,eventargs)を両方を使ってイベントを、IObservable <MyEventArgs>に変換する
        Observable
            .FromEventPattern<EventHandler<MyEventArgs>, MyEventArgs>(
            h => h.Invoke, h => _onEvent += h, h => _onEvent -= h)
            .Subscribe()
            .AddTo(disposables);

        // FromEventを使う場合
        // eventArgsのみを使ってイベントをIObservableに変換する
        Observable.FromEvent<EventHandler<MyEventArgs>, MyEventArgs>
            (h => (sender, e) => h(e),
            h => _onEvent += h,
            h => _onEvent -= h)
            .Subscribe()
            .AddTo(disposables);

        // Action<T>を使ってイベントをObservable<T>にも変換できる

        Observable.FromEvent<UnityAction>(
            h => new UnityAction(h),
            h => _uiButton.onClick.AddListener(h),
            h => _uiButton.onClick.RemoveListener(h))
            .Subscribe()
            .AddTo(disposables);

        // ただしUnityEventからObservableに変換する
        // FromEventのとうい構文としてAsObservable()が用意されている
        _uiButton.onClick.AsObservable().Subscribe().AddTo(disposables);




    }
    private void OnDestroy()
    {
        disposables.Dispose();
    }
}
