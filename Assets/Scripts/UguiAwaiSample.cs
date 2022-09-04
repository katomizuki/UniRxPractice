using Cysharp.Threading.Tasks;
using UnityEngine.UI;
using System.Threading;
using UnityEngine;

public class UguiAwaiSample : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Button button;

    [SerializeField]
    private Toggle toggle;

    [SerializeField]
    private InputField inputField;

    [SerializeField]
    private Slider slider;


    private void  Start()
    {
        var token = this.GetCancellationTokenOnDestroy();

        WaitForButton(token).Forget() ;
        WaitForInputField(token).Forget();
        WaitForSlider(token).Forget();
        WaitForToggle(token).Forget();

    }


    private async UniTaskVoid WaitForButton(CancellationToken token)
    {
        // Buttonをクリック
        using (var handle = button.GetAsyncClickEventHandler(token))
        {
            while (!token.IsCancellationRequested)
            {
                await handle.OnClickAsync();
                Debug.Log("Button Clicked");
            }
        }

    }

    private async UniTaskVoid WaitForToggle(CancellationToken token)
    {
          // Toggle状態更新
          using(var handle = toggle.GetAsyncValueChangedEventHandler())
        {
            while(!token.IsCancellationRequested)
            {
                var isOn = await handle.OnValueChangedAsync();
                Debug.Log("toggle");
            }
        }

    }


    private async UniTaskVoid WaitForInputField(CancellationToken token)
    {
        // InputField にテキストの入力完了

        using(var handler = inputField.GetAsyncEndEditEventHandler(token))
        {
            while(!token.IsCancellationRequested)
            {
                var text = await handler.OnEndEditAsync();
                Debug.Log(text);
            }
        }
    }


    private async UniTaskVoid WaitForSlider(CancellationToken token)
    {
        using( var handler = slider.GetAsyncValueChangedEventHandler(token))
        {
            while(!token.IsCancellationRequested)
            {
                var sliderValue = await handler.OnValueChangedAsync();
                Debug.Log(sliderValue);
            }
        }
     }
   

}
