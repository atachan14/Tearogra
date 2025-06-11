using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
using Toggle = UnityEngine.UI.Toggle;

public class UI_ArosSelectorField : MonoBehaviour
{
    public Unit Aro { get; private set; }

    [SerializeField] UI_ArosSelector ui_ArosSelector;

    [SerializeField] Image outLine;
    [SerializeField] Image InnerShadow;
    [SerializeField] Image aroIconImage;

    [SerializeField] Toggle toggle;
    [SerializeField] Color onColor = Color.green;
    [SerializeField] Color offColor = Color.gray;




    void Start()
    {
        UpdateOutLineColor();
        toggle.onValueChanged.AddListener(_ => UpdateOutLineColor());
        toggle.onValueChanged.AddListener(_ => SendSelectedToAroCommonds());

    }

    void UpdateOutLineColor()
    {
        outLine.color = toggle.isOn ? onColor : offColor;
    }

    void SendSelectedToAroCommonds()
    {
        if (toggle.isOn)
        {
            ui_ArosSelector.AddSelectedAro(Aro);
        }

        if (!toggle.isOn)
        {
            ui_ArosSelector.RemoveSelectedAro(Aro);
        }
    }

    public void SetAro(Unit aro)
    {
        Aro = aro;
        aroIconImage.sprite = Aro.GetComponentInChildren<IconSprites>().AroSelectorIcon;

        Aro.GetComponentInChildren<AroShadow>()
            .GetComponent<SpriteRenderer>()
            .color = InnerShadow.color;

        Aro.GetComponentInChildren<NextPosMarker>()
           .GetComponent<SpriteRenderer>()
           .color = InnerShadow.color;
    }

}
