using UnityEngine;



public class UnitCollision : MonoBehaviour
{
    Unit unit;
    Rigidbody2D rb;
    UnitParams uParams;

    [SerializeField] GameObject dmgDisplay;

    void Start()
    {
        CashRefarence();
        SetupRb();
    }

    void CashRefarence()
    {
        unit = GetComponent<Unit>();
        uParams = GetComponent<UnitParams>();
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void SetupRb()
    {
        if (rb == null) return;

        rb.mass = uParams.weight;
        rb.linearDamping = 10;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        BaseSkillAC ac = collision.GetComponent<BaseSkillAC>();
        if (ac == null) return;

        DmgExe(ac);
        MassExe(ac);
    }

    void DmgExe(BaseSkillAC ac)
    {
        foreach (var kvp in ac.attackTable)
        {
            Element element = kvp.Key;
            AttackElementData data = kvp.Value;

            int resist = uParams.GetResist(element);
            TryTakeDamage(ac, element, data, resist); // ac を追加
        }
    }

    void TryTakeDamage(BaseSkillAC ac, Element element, AttackElementData data, int resist)
    {
        if (data.damage <= 0) return;

        int dmg = CalcTakeDamage(data.damage, data.Pen, data.percentPen, resist);

        ShowDmg(element, dmg);
        uParams.ReportDmg(dmg);

        // casterがUIに送るべきかの判定も含めて、責任を移譲
        ac.acResponse.OnDamageDealt(element, dmg,unit.AroId);
    }


    void ShowDmg(Element e, int d)
    {
        GameObject dmgEffect = Instantiate(dmgDisplay, transform);
        dmgEffect.GetComponent<FloatingText>().InitDamage(e, d);
    }

    int CalcTakeDamage(int dmgBase, int penFlat, int penPercent, int resist)
    {
        float reducedResist = resist * (1f - penPercent / 100f);
        float finalResist = reducedResist - penFlat;
        float damageMultiplier = 100f / (100f + finalResist);
        int takeDamage = Mathf.FloorToInt(dmgBase * damageMultiplier);
        return Mathf.Max(0, takeDamage);
    }

    public void MassExe(BaseSkillAC ac)
    {
        Vector2 knockbackDir = (transform.position - ac.transform.position).normalized;
        float forcePower = ac.acWeight;
        rb.AddForce(knockbackDir * forcePower, ForceMode2D.Impulse);
    }
}
