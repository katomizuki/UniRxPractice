using Cysharp.Threading.Tasks;
using Unity.Jobs;
using Unity.Collections;
using UnityEngine;


public class AsyncOperationHandleAwaitSample : MonoBehaviour
{
    // Start is called before the first frame update
    private async UniTaskVoid Start()
    {
        var values = new NativeArray<int>(1000, Allocator.TempJob);

        for (int i = 0; i < values.Length; i++)
        {
            values[i] = i;
        }

        var result = await SumAsync(values);
    }


    private async UniTask<int> SumAsync(NativeArray<int> values)
    {
        // 初期化
        var results = new NativeArray<int>(1, Allocator.TempJob);

        // ジョブを作成
        var job = new SumJob(result: results, values: values);
        
        var jobHandle = job.Schedule();

        // JobHandlerをAwait
        await jobHandle;

        // 結果を格納
        var sum = job.Result[0];

        job.Result.Dispose();
        job.Values.Dispose();

        return sum;

    }

    private struct SumJob : IJob
    {
        public NativeArray<int> Result;
        public NativeArray<int> Values;

        public SumJob(NativeArray<int> result, NativeArray<int> values)
        {
            this.Result = result;
            this.Values = values;
        }

        public void Execute()
        {
            Result[0] = 0;
            for (var i = 0; i < Values.Length; i++)
            {
                Result[0] += Values[i];
            }
        }
    }
}

   


