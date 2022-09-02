using UniRx;
using UnityEngine;

public class ReactiveDictionarySample : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        var rd = new ReactiveDictionary<string, string>();

        // 要素が増えた時の通知を購読

        rd.ObserveAdd()
            .Subscribe((DictionaryAddEvent<string, string> a) => { Debug.Log("通知"); });

        rd.ObserveRemove()
            .Subscribe((DictionaryRemoveEvent<string, string> a) => { Debug.Log("通知"); });

        rd.ObserveReplace()
            .Subscribe((DictionaryReplaceEvent<string, string> a) => { Debug.Log("通知"); });

        rd.ObserveCountChanged()
            .Subscribe((int c) => { Debug.Log("通知"); });

        rd["Apple"] = "りんご";

        rd["Banan"] = "バナナ";

        rd.Remove("Apple");

        rd.Dispose();
    }

}
