using UnityEngine;

public class UnitCollision : MonoBehaviour
{

    Rigidbody2D rb;
    UnitParams unitParams;
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

    void Update()
    {
        
    }

    protected virtual void SetupRb()
    {
        if (rb == null) return;

        rb.gravityScale = 0f;                  // 重力はいらないのでオフにする
        rb.linearDamping = 2f;                 // 滑らせたいなら0、止めたいなら1〜3くらい
        rb.mass = unitParams.weight;

        rb.constraints = RigidbodyConstraints2D.FreezeRotation; // 回転は完全にロック
    }
}
