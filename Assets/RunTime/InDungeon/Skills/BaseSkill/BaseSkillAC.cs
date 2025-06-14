using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class BaseSkillAC : MonoBehaviour
{
    SkillParams skillParams;
    protected Rigidbody2D rb;


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
    protected int pPen;
    protected int fPen;
    protected int iPen;
    protected int ePen;

    Vector2 moveDirection;

    private void Start()
    {
        skillParams = GetComponentInParent<SkillParams>();
        SetupAC(skillParams);
        StartCoroutine(AutoDestroyAfterFrame());
    }
    public void SetupAC(SkillParams param)
    {
        SetupParams(param);
        SetupCols();
        SetupMoveDir(); // ← 追加
    }

    private void SetupMoveDir()
    {
        UnitState state = GetComponentInParent<UnitState>(); // 仮：UnitStateコンポーネント持ってる親がいる前提

        if (state != null)
        {
            float angleRad = state.Angle * Mathf.Deg2Rad;
            moveDirection = new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad)).normalized;
        }
        else
        {
            Debug.Log("state==null");
            moveDirection = Vector2.right; // フォールバック：とりあえず右向き
        }

    }

    void SetupParams(SkillParams param)
    {
        acFrame = param.acFrame;
        acLength = param.acLength;
        acWidth = param.acWidth;
        acSpeed = param.acSpeed;
        acWeight = param.acWeight;

        pd = param.pd;
        fd = param.fd;
        id = param.id;
        ed = param.ed;

        pPen = param.pPen;
        fPen = param.fPen;
        iPen = param.iPen;
        ePen = param.ePen;
    }

    void SetupCols()
    {
        SetupRb();
        SetupCollider();

    }
    protected virtual void SetupRb()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null) return;

        rb.gravityScale = 0f;                  // 重力はいらないのでオフにする
        rb.linearDamping = 0f;                 // 滑らせたいなら0、止めたいなら1〜3くらい
        rb.mass = acWeight;

        rb.constraints = RigidbodyConstraints2D.FreezeRotation; // 回転は完全にロック
    }

    void SetupCollider()
    {
        Collider2D col = GetComponent<Collider2D>();

        if (col == null)
        {
            Debug.LogError("Collider2Dがない！");
            return;
        }

        if (!rb)
        {
            // Rigidbodyがなかったらトリガーにする。
            col.isTrigger = true;
        }

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
    private void Update()
    {
        if (rb != null)
        {
            Vector2 nextPos = rb.position + moveDirection * acSpeed * Time.deltaTime;
            rb.MovePosition(nextPos);
        }
    }

}
