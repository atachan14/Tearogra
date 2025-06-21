using System.Collections;
using UnityEngine;

public class BaseSkillAC : MonoBehaviour
{
    public SkillParams sParams;
    public UnitParams uParams;
    
    public float acWeight;

    private void Start()
    {
        sParams = GetComponentInParent<SkillParams>();
        uParams = GetComponentInParent<UnitParams>();

        SetupCollider();
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

    private IEnumerator AutoDestroyAfterFrame()
    {
        yield return new WaitForSeconds(sParams.Get(ParamType.acFrame));
        Destroy(gameObject);
    }


    // 🔽 Damage計算系（都度使うとき用）
    public int GetOutPd() => (int)(sParams.Get(ParamType.pd) * uParams.pb / 100f);
    public int GetOutFd() => (int)(sParams.Get(ParamType.fd) * uParams.fb / 100f);
    public int GetOutId() => (int)(sParams.Get(ParamType.id) * uParams.ib / 100f);
    public int GetOutVd() => (int)(sParams.Get(ParamType.vd) * uParams.vb / 100f);

    // 🔽 Penetration値
    public int GetOutPPen() => (int)sParams.Get(ParamType.pPen) + uParams.pPen;
    public int GetOutFPen() => (int)sParams.Get(ParamType.fPen) + uParams.fPen;
    public int GetOutIPen() => (int)sParams.Get(ParamType.iPen) + uParams.iPen;
    public int GetOutVPen() => (int)sParams.Get(ParamType.vPen) + uParams.vPen;

    // 🔽 Penetrationパーセンテージ
    public int GetOutPPenPer() => (int)sParams.Get(ParamType.pPenPer) + uParams.pPenPer;
    public int GetOutFPenPer() => (int)sParams.Get(ParamType.fPenPer) + uParams.fPenPer;
    public int GetOutIPenPer() => (int)sParams.Get(ParamType.iPenPer) + uParams.iPenPer;
    public int GetOutVPenPer() => (int)sParams.Get(ParamType.vPenPer) + uParams.vPenPer;
}
