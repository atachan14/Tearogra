using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;




public class Unit : MonoBehaviour
{
    public UnitParams uParams;
    public UnitState state;

    public int? AroId { get; set; } = null;

    void CasheReference()
    {
        uParams = GetComponent<UnitParams>();
        state = GetComponent<UnitState>();
    }

   


    public void FloorSetup(int? aroId)
    {
        CasheReference();

        gameObject.SetActive(true);

        AroId = aroId;

        state.FloorSetup();

        var skillParams = GetComponentsInChildren<SkillParams>();
        foreach (var skill in skillParams)
        {
            skill.SetupSkill();
        }

        GetComponentInChildren<AroLight>()?.FloorSetup();
    }

    public void BreakSetup(int? aroId)
    {
        CasheReference();

        gameObject.SetActive(true);

        AroId = aroId;

        state.BreakSetup();

        var skillParams = GetComponentsInChildren<SkillParams>();
        foreach (var skill in skillParams)
        {
            skill.SetupSkill();
        }

        GetComponentInChildren<AroLight>()?.BreakSetup();
    }


    public void GoHole(Transform hole)
    {
        StartCoroutine(HoleJumpAnimation(hole.position));
    }

    IEnumerator HoleJumpAnimation(Vector3 targetPos)
    {
        float duration = 0.5f;
        float elapsed = 0f;
        Vector3 startPos = transform.position;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;

            // 緩急つけたジャンプ（ちょい浮かせ）
            float heightOffset = Mathf.Sin(t * Mathf.PI) * 0.5f;
            Vector3 pos = Vector3.Lerp(startPos, targetPos, t) + Vector3.up * heightOffset;

            transform.position = pos;
            yield return null;
        }

        // 完了後は消える（または非表示）
        AfterGoHole();
    }

    void AfterGoHole()
    {

        gameObject.SetActive(false);

        if (AroId == null) return;
        HoleManager.Instance.EnteredHole(this);

    }


    public void Death()
    {
        uParams.hp = 0;
        CollisionOff();
        ItemDrop();
        state.NextPos = transform.position;

        StartCoroutine(DeathAnimation());
        if (AroId != null)
        {
            AroManager.Instance.AroDict[(int)AroId] = null;
        }
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

        if (AroId != null)
        {
            UI_ArosSelector.Instance.ReportDeath((int)AroId);
        }

        Destroy(gameObject);
    }
}
