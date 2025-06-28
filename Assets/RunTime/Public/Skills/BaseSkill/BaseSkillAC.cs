using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSkillAC : MonoBehaviour
{
    public SkillParams sParams;
    public UnitParams uParams;
    public BaseACResponse acResponse;

    public float acWeight;
    public Dictionary<Element, AttackElementData> attackTable;

    private void Start()
    {
        sParams = GetComponentInParent<SkillParams>();
        uParams = GetComponentInParent<UnitParams>();
        acResponse = GetComponentInParent<BaseACResponse>();

        SetupCollider();
        SetupParams();
        StartCoroutine(AutoDestroyAfterFrame());
    }

    void SetupCollider()
    {
        Collider2D col = GetComponent<Collider2D>();

        if (col == null)
        {
            Debug.LogError("Collider2Dがない！");
            return;
        }

        col.isTrigger = true;

        var acLength = sParams.Get(ParamType.acLength);
        var acWidth = sParams.Get(ParamType.acWidth);

        if (col is BoxCollider2D box)
        {
            Vector2 originalSize = box.size;
            box.size = new Vector2(
                originalSize.x * acLength,
                originalSize.y * acWidth
            );
        }
        else if (col is CircleCollider2D circle)
        {
            float originalRadius = circle.radius;
            circle.radius = originalRadius * acLength;
        }
        else
        {
            Debug.LogWarning("未対応Collider2DType: " + col.GetType());
        }
    }

    void SetupParams()
    {
        attackTable = new Dictionary<Element, AttackElementData>();

        foreach (Element element in System.Enum.GetValues(typeof(Element)))
        {
            float baseDmg = sParams.Get(element switch
            {
                Element.Physic => ParamType.pd,
                Element.Fire => ParamType.fd,
                Element.Ice => ParamType.id,
                Element.Volt => ParamType.vd,
                _ => ParamType.pd // fallback（来ないけど）
            });

            int damage = (int)(baseDmg * uParams.attackBonus[element] / 100f);

            int pen = (int)sParams.Get(element switch
            {
                Element.Physic => ParamType.pPen,
                Element.Fire => ParamType.fPen,
                Element.Ice => ParamType.iPen,
                Element.Volt => ParamType.vPen,
                _ => ParamType.pPen
            }) + uParams.penFlat[element];

            int penPer = (int)sParams.Get(element switch
            {
                Element.Physic => ParamType.pPenPer,
                Element.Fire => ParamType.fPenPer,
                Element.Ice => ParamType.iPenPer,
                Element.Volt => ParamType.vPenPer,
                _ => ParamType.pPenPer
            }) + uParams.penPercent[element];

            attackTable[element] = new AttackElementData(damage, pen, penPer);
        }
    }

    private IEnumerator AutoDestroyAfterFrame()
    {
        yield return new WaitForSeconds(sParams.Get(ParamType.acFrame));
        Destroy(gameObject);
    }
}

public struct AttackElementData
{
    public int damage;
    public int Pen;
    public int percentPen;

    public AttackElementData(int dmg, int pen, int penPer)
    {
        damage = dmg;
        Pen = pen;
        percentPen = penPer;
    }
}
