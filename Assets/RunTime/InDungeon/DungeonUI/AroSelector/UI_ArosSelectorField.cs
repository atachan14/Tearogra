using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
using Toggle = UnityEngine.UI.Toggle;

public class UI_ArosSelectorField : MonoBehaviour
{
    [SerializeField] Image outLine;
    [SerializeField] Image InnerShadow;
    [SerializeField] Image aroIconImage;

    [SerializeField] Toggle toggle;
    [SerializeField] Color onColor = Color.green;
    [SerializeField] Color offColor = Color.gray;

    [SerializeField] UI_AroCommonds ui_AroCommonds;



    public GameObject Aro { get; private set; }

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
            ui_AroCommonds.SetSelectedAro(Aro);
        }
    }

    public void SetAro(GameObject aro)
    {
        Aro = aro;
        aroIconImage.sprite = Aro.GetComponentInChildren<CreatureSprite>().AroSelecterIcon.sprite;

        Aro.GetComponentInChildren<AroShadow>()
            .GetComponent<SpriteRenderer>()
            .color = InnerShadow.color;

        Aro.GetComponentInChildren<NextPosMarker>()
           .GetComponent<SpriteRenderer>()
           .color = InnerShadow.color;
    }

}
