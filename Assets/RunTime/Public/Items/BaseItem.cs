using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class BaseItem : MonoBehaviour
{
    SpriteRenderer sr;
    CircleCollider2D col;
    Rigidbody2D rb;

    protected virtual void Start()
    {
        CashReference();
    }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   

    protected virtual void CashReference()
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        rb.linearDamping = 50;
    }

    public virtual void OnDrop()
    {
        sr.enabled = true;
        col.enabled = true;
        transform.SetParent(DropItem.Instance.transform);

        Vector2 randomDir = Random.insideUnitCircle.normalized;
        float force = Random.Range(1f, 3f); // êîéöÇÕí≤êÆÇµÇƒ
        rb.AddForce(randomDir * force, ForceMode2D.Impulse);
    }

    public virtual void Collect(Unit u)
    {
        sr.enabled = false;
        col.enabled = false;
        transform.SetParent(u.GetComponentInChildren<UnitItem>().transform);
    }
}
