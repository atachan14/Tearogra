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
    }

    public virtual void OnDrop()
    {
        sr.enabled = true;
        col.enabled = true;
        transform.SetParent(transform.root.GetComponentInChildren<DropItem>().transform);
    }
}
