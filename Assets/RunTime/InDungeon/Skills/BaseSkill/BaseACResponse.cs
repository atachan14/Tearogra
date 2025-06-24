using UnityEngine;

public class BaseACResponse : MonoBehaviour
{
    UnitParams uParams;
    SkillParams sParams;

    void Awake()
    {
        uParams = GetComponentInParent<UnitParams>();
        sParams = GetComponent<SkillParams>();
    }

    public void OnDamageDealt(Element e, int dmg)
    {
        TrySendToUIDamageGraph(e, dmg);
        TryOmniVamp(e, dmg); // âº
    }

    void TrySendToUIDamageGraph(Element e, int dmg)
    {
        if (uParams.AroId == null) return;

        UI_DmgGraph.Instance.ReportDamage(uParams.AroId.Value, e, dmg);
    }

    void TryOmniVamp(Element e, int dmg)
    {
        // è´óàóp
    }
}
