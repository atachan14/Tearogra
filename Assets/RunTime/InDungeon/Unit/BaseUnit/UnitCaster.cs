using UnityEngine;

public class UnitCaster : MonoBehaviour
{
    UnitParams unitParams;

    void Awake()
    {
        unitParams = GetComponent<UnitParams>();
    }

    public void OnDamageDealt(Element e, int dmg)
    {
        TrySendToUIDamageGraph(e, dmg);
        TryOmniVamp(e, dmg); // âº
    }

    void TrySendToUIDamageGraph(Element e, int dmg)
    {
        if (unitParams.AroId == null) return;

        UI_DmgGraph.Instance.ReportDamage(unitParams.AroId.Value, e, dmg);
    }

    void TryOmniVamp(Element e, int dmg)
    {
        // è´óàóp
    }
}
