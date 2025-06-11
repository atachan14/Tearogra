using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UI_ArosSelector : MonoBehaviour
{
    public UI_ArosSelectorField[] aroSelectorFields = new UI_ArosSelectorField[5];
    [SerializeField] UI_AroCommonds aroCommonds;
    Toggle lastOnToggle;
    public List<Unit> SelectedAros  = new();

    void Start()
    {
        SetupArosSelecterFields();
    }

    void SetupArosSelecterFields()
    {
        var aroList = PlayerData.Instance.GetComponentsInChildren<Unit>();

        if (aroList.Length != aroSelectorFields.Length)
        {
            Debug.LogError("aroSelecterFieldsÇ∆PlayerDataì‡ÇÃCreatureêîÇ™àÍívÇµÇƒÇ‹ÇπÇÒÅB");
            return;
        }

        for (int i = 0; i < aroSelectorFields.Length; i++)
        {
            aroSelectorFields[i].SetAro(aroList[i]);
        }
    }

    public void AddSelectedAro(Unit aro)
    {
        SelectedAros.Add(aro);
        aroCommonds.UpdateSelectedAro(aro);
    }
    public void RemoveSelectedAro(Unit aro)
    {
        SelectedAros.Remove(aro);
    }



}
