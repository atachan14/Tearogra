using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class UI_ArosSelectorType : MonoBehaviour
{
    [SerializeField] Toggle aroSelectorTypeToggle;
    [SerializeField] ToggleGroup toggleGroup;
    void Start()
    {
        aroSelectorTypeToggle.onValueChanged.AddListener((isOn) =>
        {
            toggleGroup.enabled = isOn;
        });
    }
}
