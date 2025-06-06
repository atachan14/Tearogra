using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UI_ArosSelector : MonoBehaviour
{
    public UI_ArosSelectorField[] aroSelectorFields = new UI_ArosSelectorField[5];
    Toggle lastOnToggle;

    void Start()
    {
        SetupArosSelecterFields();
    }

    void SetupArosSelecterFields()
    {
        var aroList = PlayerData.Instance.GetComponentsInChildren<Unit>();

        if (aroList.Length != aroSelectorFields.Length)
        {
            Debug.LogError("aroSelecterFieldsとPlayerData内のCreature数が一致してません。死にます。");
            return;
        }

        for (int i = 0; i < aroSelectorFields.Length; i++)
        {
            aroSelectorFields[i].SetAro(aroList[i].gameObject);
        }
    }

   
}
