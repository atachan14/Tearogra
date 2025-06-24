using System;
using System.Collections;
using UnityEngine;

public class Unit : MonoBehaviour
{
    UnitParams uParams;
    UnitState state;

    private void Start()
    {
        CasheReference();
    }

    void CasheReference()
    {
        uParams = GetComponent<UnitParams>();
        state = GetComponent<UnitState>();
    }

    public void SetupUnit()
    {
        GetComponent<UnitState>().FloorSetup();

        var skillParams = GetComponentsInChildren<SkillParams>();
        foreach (var skill in skillParams)
        {
            skill.SetupSkill();
        }
    }

    public void Death()
    {
        uParams.hp = 0;
        CollisionOff();
        ItemDrop();
        state.NextPos = transform.position;

        StartCoroutine(DeathAnimation());
    }

    void CollisionOff()
    {
        var cols = GetComponentsInChildren<Collider2D>();
        foreach (var col in cols)
        {
            col.enabled = false;
        }
    }

    void ItemDrop()
    {
        var items = GetComponentsInChildren<BaseItem>();
        foreach (var item in items)
        {
            item.OnDrop();
        }
    }

    IEnumerator DeathAnimation()
    {
        var body = GetComponentInChildren<BodySprite>();
        if (body != null)
            body.transform.rotation = Quaternion.Euler(0, 0, 90);

        SpriteRenderer[] renderers = body.GetComponentsInChildren<SpriteRenderer>();
        float duration = 1.5f;
        float time = 0f;

        while (time < duration)
        {
            float alpha = Mathf.Lerp(1f, 0f, time / duration);
            foreach (var rend in renderers)
            {
                Color c = rend.color;
                rend.color = new Color(c.r, c.g, c.b, alpha);
            }

            time += Time.deltaTime;
            yield return null;
        }

        if(uParams.AroId != null)
        {
            UI_ArosSelector.Instance.ReportDeath((int)uParams.AroId);
        }

        Destroy(gameObject);
    }
}
