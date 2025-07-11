using System.Collections.Generic;
using System.Linq;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.UI;

public class UI_ArosSelector : MonoBehaviour
{
    public static UI_ArosSelector Instance;
    
    public UI_ArosSelectorField[] aroSelectorFields = new UI_ArosSelectorField[5];
    Toggle lastOnToggle;

    public List<Unit> SelectedAros = new();
    public Unit LastSelectedAro => SelectedAros.LastOrDefault();

    private void Awake()
    {
        Instance = this;
    }


    public void FloorSetup()
    {
        SetupArosSelecterFields();
    }

   

    void SetupArosSelecterFields()
    {
        for (int i = 0; i < AroManager.Instance.AroDict.Count(); i++)
        {
            aroSelectorFields[i].SetAro(AroManager.Instance.AroDict[i]);
           
        }
    }
  

    public void AddSelectedAro(Unit aro)
    {
        SelectedAros.Add(aro);
        HighlightSelected();
        UI_AroCommonds.Instance.UpdateSelectedAro(aro);
    }
    public void RemoveSelectedAro(Unit aro)
    {
        SelectedAros.Remove(aro);
        HighlightSelected();
        UI_AroCommonds.Instance.UpdateSelectedAro(aro);
    }

   

    public void HighlightSelected()
    {
        // 全部リセット
        foreach (var field in aroSelectorFields)
        {
            field.UpdateOutLineColor();
        }

        // 最後のやつだけ色変える
        if (LastSelectedAro != null)
        {
            var field = aroSelectorFields.FirstOrDefault(f => f.Aro == LastSelectedAro);
            if (field != null)
            {
                field.UpdateLastAro();
            }
        }
    }

    public void ReportDeath(int aroId)
    {
        var deadUnit = aroSelectorFields[aroId].Aro;

        // UI に死んだ処理をさせる
        aroSelectorFields[aroId].ReceiveDeath();
        UI_DmgGraph.Instance.rows[aroId].ReceiveDeath();

        // 選択中リストから除外
        if (SelectedAros.Contains(deadUnit))
        {
            RemoveSelectedAro(deadUnit);
        }
    }
}
