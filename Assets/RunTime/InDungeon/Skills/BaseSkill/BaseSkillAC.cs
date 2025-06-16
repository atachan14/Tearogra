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
    protected float acWeight;

    [Header("Damage")]
    protected int pd;
    protected int fd;
    protected int id;
    protected int ed;

    [Header("Penetration")]
    public int pPen;
    public int fPen;
    public int iPen;
    public int ePen;

    [Header("PenetrationPercent")]
    public int pPenPer;
    public int fPenPer;
    public int iPenPer;
    public int ePenPer;

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


        outPd = pd * uParams.pb / 100;
        outFd = fd * uParams.fb / 100;
        outId = id * uParams.ib / 100;
        outVd = ed * uParams.vb / 100;

        outPPen = pPen + uParams.pPen;
        outFPen = fPen + uParams.pPen;
        outIPen = iPen + uParams.iPen;
        outVPen = fPen + uParams.pPen;

        outPPenPer = pPenPer + uParams.pPenPer;
        outFPenPer = fPenPer + uParams.fPenPer;
        outIPenPer = iPenPer + uParams.iPenPer;
        outVPenPer = ePenPer + uParams.vPenPer;

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
