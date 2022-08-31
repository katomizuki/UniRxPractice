using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class MySubject<T> : ISubject<T>
{

    public bool IsStopped { get; } = false;
    public bool IsDisposed { get; } = false;
    private readonly object _lockObject = new object();
    private Exception error;
    // 自身を購読しているObseverリスト
    private List<IObserver<T>> observers;

    public MySubject()
    {
        observers = new List<IObserver<T>>();
    }

    public void OnCompleted()
    {
        lock(_lockObject)
        {
            ThrowIfDisposed();
            if (IsDisposed) return;
            try
            {
                foreach (var observer in observers)
                {
                    observer.OnCompleted();
                }
            }
            finally
            {
                OnDispose();
            }
        }
    }

    public void OnError(Exception error)
    {
        lock(_lockObject)
        {
            ThrowIfDisposed();

            if (IsStopped) return;
            this.error = error;
        }
        try
        {
            foreach(var observer in observers)
            {
                observer.OnError(error);
            }
        }
        finally
        {
            OnDispose();
        }
    }



    public void OnNext(T value)
    {
        if (IsStopped) return;
        lock (_lockObject)
        {
            ThrowIfDisposed();
        }
    }

    public IDisposable Subscribe(IObserver<T> observer)
    {
        lock(_lockObject)
        {
            if(IsStopped)
            {
                // すでに動作を終了しているならOnErrorメッセージ
                if (error != null)
                {
                    observer.OnError(error);
                }
                else
                {
                    observer.OnCompleted();
                }
                return Disposable.Empty;
            }
            observers.Add(observer);
            return new Subscription(observer, this);
        }
    }

    private void ThrowIfDisposed()
    {
        // リストに追加する
        if (IsDisposed) throw new ObjectDisposedException("MySubject");
    }

    private  class Subscription: IDisposable
    {
        private readonly IObserver<T> _observer;
        private readonly MySubject<T> _parent;

        public Subscription(IObserver<T> observer, MySubject<T> parent)
        {
            this._observer = observer;
            this._parent = parent;
        }

        public void Dispose()
        {
            _parent.observers.Remove(_observer);
        }
    }

    public void OnDispose()
    {
        lock (_lockObject)
        {
            if(!IsDisposed)
            {
                observers.Clear();
                observers = null;
                error = null;
            }
        }
    }

   
}
