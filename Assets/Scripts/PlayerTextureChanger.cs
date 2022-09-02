using UniRx;
using UnityEngine;

public class PlayerTextureChanger : MonoBehaviour
{
    [SerializeField]
    private AsyncSubject asyncSubject;
    // Start is called before the first frame update
    void Start()
    {
        asyncSubject.PlayerTextureAsync
            .Subscribe(SetMyTexture)
            .AddTo(this);
    }

    private void SetMyTexture(Texture newTexture)
    {
        var r = GetComponent<Renderer>();
        r.sharedMaterial.mainTexture = newTexture;
    }
}
