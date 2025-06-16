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
        //メソッドごともういらんかも。
        if (rb == null) return;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation; // 回転は完全にロック
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Hit AC: {collision.gameObject.name}, id: {collision.gameObject.GetInstanceID()}");
        BaseSkillAC ac = collision.GetComponent<BaseSkillAC>();

        if (ac == null)
        {
            return;
        }

        DmgExe(ac);
        MassExe();
        UI_DmgDisplayExe();
       
    }

    void DmgExe(BaseSkillAC ac)
    {
        // 属性別に処理をまとめる
        TryTakeDamage(Element.Physic, ac.outPd, ac.outPPen, ac.outPPenPer, unitParams.pr);
        TryTakeDamage(Element.Fire, ac.outFd, ac.outFPen, ac.outFPenPer, unitParams.fr);
        TryTakeDamage(Element.Ice, ac.outId, ac.outIPen, ac.outIPenPer, unitParams.ir);
        TryTakeDamage(Element.Volt, ac.outVd, ac.outVPen, ac.outVPenPer, unitParams.vr);
    }
    void TryTakeDamage(Element element, int xd, int xp, int xpp, int xr)
    {
        if (xd <= 0) return;

        int dmg = CalcTakeDamage(xd, xp, xpp, xr);

        ShowDmg(element,dmg);
        unitParams.ReceiveDmg(dmg);
        

    }

    void ShowDmg(Element e,int d)
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

    void MassExe()
    {

    }

    void UI_DmgDisplayExe()
    {

    }

}
