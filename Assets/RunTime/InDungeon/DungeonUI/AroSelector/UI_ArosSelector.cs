using System.Collections.Generic;
using System.Linq;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.UI;

public class UI_ArosSelector : MonoBehaviour
{
    public static UI_ArosSelector Instance;
    Unit[] aroList;
    public UI_ArosSelectorField[] aroSelectorFields = new UI_ArosSelectorField[5];
    Toggle lastOnToggle;

    public List<Unit> SelectedAros = new();
    public Unit LastSelectedAro => SelectedAros.LastOrDefault();

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdateAroList();
    }

    public void UpdateAroList()
    {
        SetupArosSelecterFields();
        SetupDmgGraph();
    }

   

    void SetupArosSelecterFields()
    {
        aroList = PlayerData.Instance.GetComponentsInChildren<Unit>();

        if (aroList.Length > aroSelectorFields.Length)
        {
            Debug.LogError("aroSelecterFields���PlayerData����Creature���������ł��B");
            return;
        }

        for (int i = 0; i < aroList.Length; i++)
        {
            aroSelectorFields[i].SetAro(aroList[i]);
            aroList[i].GetComponent<UnitParams>().AroId = i;
            aroList[i].SetupUnit();
        }
    }
    void SetupDmgGraph()
    {
        UI_DmgGraph.Instance.SetupIcon(aroList);
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
        // �S�����Z�b�g
        foreach (var field in aroSelectorFields)
        {
            field.UpdateOutLineColor();
        }

        // �Ō�̂�����F�ς���
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

        // UI �Ɏ��񂾏�����������
        aroSelectorFields[aroId].ReceiveDeath();
        UI_DmgGraph.Instance.rows[aroId].ReceiveDeath();

        // �I�𒆃��X�g���珜�O
        if (SelectedAros.Contains(deadUnit))
        {
            RemoveSelectedAro(deadUnit);
        }
    }
}
