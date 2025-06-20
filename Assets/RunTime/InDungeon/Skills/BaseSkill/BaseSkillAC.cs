using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class BaseSkillAC : MonoBehaviour
{
    public SkillParams sParams;
    public UnitParams uParams;

    public int outPd;
    public int outFd;
    public int outId;
    public int outVd;

    public int outPPen;
    public int outFPen;
    public int outIPen;
    public int outVPen;

    public int outPPenPer;
    public int outFPenPer;
    public int outIPenPer;
    public int outVPenPer;





    [Header("AttackCollision")]
    protected float acFrame;
    protected float acLength;
    protected float acWidth;
    protected float acSpeed;
    public float acWeight;

    [Header("Damage")]
    protected float pd;
    protected float fd;
    protected float id;
    protected float ed;

    [Header("Penetration")]
    protected float pPen;
    protected float fPen;
    protected float iPen;
    protected float ePen;

    [Header("PenetrationPercent")]
    protected float pPenPer;
    protected float fPenPer;
    protected float iPenPer;
    protected float ePenPer;

    private void Start()
    {
        sParams = GetComponentInParent<SkillParams>();
        uParams = GetComponentInParent<UnitParams>();

        SetupAC();
        StartCoroutine(AutoDestroyAfterFrame());
    }
    public void SetupAC()
    {
        SetupParams();
        SetupCols();
    }



    void SetupParams()
    {
        acFrame = sParams.acFrame;
        acLength = sParams.acLength;
        acWidth = sParams.acWidth;
        acSpeed = sParams.acSpeed;
        acWeight = sParams.acWeight;

        pd = sParams.pd;
        fd = sParams.fd;
        id = sParams.id;
        ed = sParams.ed;

        pPen = sParams.pPen;
        fPen = sParams.fPen;
        iPen = sParams.iPen;
        ePen = sParams.ePen;

        pPenPer = sParams.pPenPer;
        fPenPer = sParams.fPenPer;
        iPenPer = sParams.iPenPer;
        ePenPer = sParams.ePenPer;


        outPd = (int)pd * uParams.pb / 100;
        outFd = (int)fd * uParams.fb / 100;
        outId = (int)id * uParams.ib / 100;
        outVd = (int)ed * uParams.vb / 100;

        outPPen = (int)pPen + uParams.pPen;
        outFPen = (int)fPen + uParams.pPen;
        outIPen = (int)iPen + uParams.iPen;
        outVPen = (int)fPen + uParams.pPen;

        outPPenPer = (int)pPenPer + uParams.pPenPer;
        outFPenPer = (int)fPenPer + uParams.fPenPer;
        outIPenPer = (int)iPenPer + uParams.iPenPer;
        outVPenPer = (int)ePenPer + uParams.vPenPer;

    }

    void SetupCols()
    {
        SetupCollider();

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
            Debug.LogWarning("未対応Collider2DType" + col.GetType());
        }
    }



    private IEnumerator AutoDestroyAfterFrame()
    {
        yield return new WaitForSeconds(acFrame);
        Destroy(gameObject);
    }


}
