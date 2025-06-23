using UnityEngine;

public class UnitCaster : MonoBehaviour
{
    BaseUnitParams unitParams;

    void Awake()
    {
        unitParams = GetComponent<BaseUnitParams>();
    }

    public void OnDamageDealt(Element e, int dmg)
    {
        TrySendToUIDamageGraph(e, dmg);
        TryOmniVamp(e, dmg); // ��
    }

    void TrySendToUIDamageGraph(Element e, int dmg)
    {
        if (unitParams.AroId == null) return;

        UI_DmgGraph.Instance.ReportDamage(unitParams.AroId.Value, e, dmg);
    }

    void TryOmniVamp(Element e, int dmg)
    {
        // �����p
    }
}
