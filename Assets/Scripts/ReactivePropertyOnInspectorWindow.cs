using UniRx;
using UnityEngine;

public class ReactivePropertyOnInspectorWindow : MonoBehaviour
{
    // ジェネリック版を表示しない
    public ReactiveProperty<int> A;
    // Int 固定版　表示される
    public IntReactiveProperty B;
    void Start()
    {
        
    }
}
