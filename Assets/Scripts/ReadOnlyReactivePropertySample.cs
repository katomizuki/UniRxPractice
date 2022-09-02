using UniRx;
using UnityEngine;

public class ReadOnlyReactivePropertySample : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        // int型のReactiveProperty
        var intReactiveProperty = new ReactiveProperty<int>(100);

        // int型のReadOnlyReactiveProperty
        var readOnlyInt = intReactiveProperty.ToReadOnlyReactiveProperty();

        // valueに直接値を設定できない

        readOnlyInt.Subscribe(x => Debug.Log("next"));

        readOnlyInt.Dispose();

    }
}
