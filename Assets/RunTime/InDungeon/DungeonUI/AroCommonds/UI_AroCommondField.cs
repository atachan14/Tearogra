using UnityEngine;
using UnityEngine.UI;

public class AroCommondField : MonoBehaviour
{
    [SerializeField] Toggle toggle;
    [SerializeField] Image image;
    [SerializeField] Sprite spriteOn;
    [SerializeField] Sprite spriteOff;

    void Start()
    {
        toggle.onValueChanged.AddListener((isOn) =>
        {
            image.sprite = isOn ? spriteOn : spriteOff;
        });
    }
}
