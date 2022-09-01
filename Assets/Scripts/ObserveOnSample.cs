using UniRx;
using UnityEngine;
using System.IO;
using System.Threading.Tasks;

public class ObserveOnSample : MonoBehaviour
{
    private void Start()
    {
        var task = Task.Run(() => File.ReadAllText(@"data.txt"));

        // Task -> Observableに変換
        // この時の実行テキストはスレッドプールのまま
        task.ToObservable()
            // 実行コンテキストをメインスレッドにスイッチングする
            .ObserveOn(Scheduler.MainThread)
            .Subscribe(x => {
                Debug.Log(x);
            });

      
    }
}
