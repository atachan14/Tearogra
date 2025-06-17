using UnityEngine;
public enum Element
{
    Physic,
    Fire,
    Ice,
    Volt
}
public struct ElementData
{
    public int damage;
    public int Pen;
    public int percentPen;
    public int resist;

    public ElementData(int xd, int xp, int xpp, int xr)
    {
        damage = xd;
        Pen = xp;
        percentPen = xpp;
        resist = xr;
    }
}

public class UnitCollision : MonoBehaviour
{

    Rigidbody2D rb;
    UnitParams unitParams;
    [SerializeField] GameObject dmgDisplay;
    void Start()
    {
        CashRefarence();
        SetupRb();
    }

    void CashRefarence()
    {
        unitParams = GetComponentInParent<UnitParams>();
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void SetupRb()
    {
        if (rb == null) return;

        rb.mass = unitParams.weight;
        rb.linearDamping = 50;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation; // 回転は完全にロック
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        BaseSkillAC ac = collision.GetComponent<BaseSkillAC>();

        if (ac == null)
        {
            return;
        }

        DmgExe(ac);
        MassExe(ac);

    }

    void DmgExe(BaseSkillAC ac)
    {
        int? aroId = ac.uParams.AroId;
        // 属性別に処理をまとめる
        TryTakeDamage(Element.Physic, ac.outPd, ac.outPPen, ac.outPPenPer, unitParams.pr, aroId);
        TryTakeDamage(Element.Fire, ac.outFd, ac.outFPen, ac.outFPenPer, unitParams.fr, aroId);
        TryTakeDamage(Element.Ice, ac.outId, ac.outIPen, ac.outIPenPer, unitParams.ir, aroId);
        TryTakeDamage(Element.Volt, ac.outVd, ac.outVPen, ac.outVPenPer, unitParams.vr, aroId);
    }
    void TryTakeDamage(Element element, int xd, int xp, int xpp, int xr, int? aroId)
    {
        if (xd <= 0) return;

        int dmg = CalcTakeDamage(xd, xp, xpp, xr);

        ShowDmg(element, dmg);

        unitParams.ReportDmg(dmg);

        if (aroId != null)
        {
            UI_DmgGraph.Instance.ReportDamage((int)aroId, element, dmg);
        }
    }

    void ShowDmg(Element e, int d)
    {
        GameObject dmgEffect = Instantiate(dmgDisplay, transform);
        dmgEffect.GetComponent<FloatingText>().InitDamage(e, d);
    }

    int CalcTakeDamage(int xd, int xp, int xpp, int xr)
    {
        // 割合貫通は百分率として扱う
        float reducedResist = xr * (1f - xpp / 100f);
        float finalResist = reducedResist - xp;

        // LoLだと防御がマイナスでもいい（ダメージ増える）
        float damageMultiplier = 100f / (100f + finalResist);

        // ダメージを最終的に切り捨て or 四捨五入
        int takeDamage = Mathf.FloorToInt(xd * damageMultiplier);
        return Mathf.Max(0, takeDamage); // 念のためマイナス対策
    }

    public void MassExe(BaseSkillAC ac)
    {
       

        // 吹っ飛ぶ方向
        Vector2 knockbackDir = (transform.position - ac.transform.position).normalized;

        // 攻撃スキルの力をそのまま使う（質量でノックバック差が出る）
        float forcePower = ac.acWeight;

        // ガツンとノックバック
        rb.AddForce(knockbackDir * forcePower, ForceMode2D.Impulse);
    }



}
