using UniRx;
using UnityEngine;

public class ReactiveCollectionSample : MonoBehaviour
{

    private void Start()
    {
        var rc = new ReactiveCollection<int>();

        // 要素が増えた時
        rc.ObserveAdd()
            .Subscribe((CollectionAddEvent<int> a) =>
            {
                Debug.Log("通知");
            });

        //要素が削除
        rc.ObserveRemove()
            .Subscribe((CollectionRemoveEvent<int> r) =>
            {
                Debug.Log("通知");
            });

        rc.ObserveReplace()
            .Subscribe((CollectionReplaceEvent<int> r) => {
                Debug.Log("通知");
            });

        rc.ObserveCountChanged()
            .Subscribe((int c) =>
            {
                Debug.Log("通知");
            });


        rc.ObserveMove()
            .Subscribe((CollectionMoveEvent<int> x) => {
                Debug.Log("通知");
            });

        rc.Add(1);
        rc[1] = 3;
        rc.RemoveAt(0);
        rc.Dispose();
 }
}
