using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class UI_ArosSelectorAll : MonoBehaviour
{
    Button allButton;
    UI_ArosSelector selector;
    UI_ArosSelectorField[] fields;

    private void Start()
    {
        allButton = GetComponent<Button>();
        selector = GetComponentInParent<UI_ArosSelector>();
        fields = GetComponentsInChildren<UI_ArosSelectorField>();
    }

    public void Click()
    {
        if (selector.SelectedAros.Count == 0)
        {
            foreach(UI_ArosSelectorField f in fields)
            {
                if(f.Aro) f.ChangeIsOn(true);
            }
        }
        else
        {
            foreach (UI_ArosSelectorField f in fields)
            {
                f.ChangeIsOn(false);
            }
        }
    }
}
