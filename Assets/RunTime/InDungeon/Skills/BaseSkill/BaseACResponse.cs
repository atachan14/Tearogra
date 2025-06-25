using UnityEngine;

public class BaseACResponse : MonoBehaviour
{
    Unit unit;
    SkillParams sParams;

    void Awake()
    {
        unit = GetComponentInParent<Unit>();
        sParams = GetComponent<SkillParams>();
    }

    public void OnDamageDealt(Element e, int dmg,int? tankId)
    {
        TrySendToUIDamageGraph(e, dmg, tankId);
        TryOmniVamp(e, dmg); // âº
    }

    void TrySendToUIDamageGraph(Element e, int dmg, int? tankId)
    {

        UI_DmgGraph.Instance.ReportDamage(e,unit.AroId, tankId, dmg);
    }

    void TryOmniVamp(Element e, int dmg)
    {
        // è´óàóp
    }
}
