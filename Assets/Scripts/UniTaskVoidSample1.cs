using System.IO;
using Cysharp.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine;

public class UniTaskVoidSample1 : MonoBehaviour
{
    [SerializeField]
    private Button button;

    [SerializeField]
    private InputField _pathInputField;

    // Start is called before the first frame update
    private void Start()
    {
        button.onClick
            .AddListener(() => UniTask.Void(async () => {
                var path = _pathInputField.text;
                var result = await ReadFileAsync(path);
                Debug.Log(result);
            }));
    }

    // 指定パスのファイルを読み込む
    [System.Obsolete]
    private async UniTask<string> ReadFileAsync(string path)
    {
        return await UniTask.Run((p) => File.ReadAllText((string) p), path);
    }
}
