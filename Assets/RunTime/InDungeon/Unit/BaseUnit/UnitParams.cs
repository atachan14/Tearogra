using System.Collections;
using UnityEngine;

public class UnitParams : MonoBehaviour
{
    UnitState state;
    StatusBar statusBar;
    public int maxhp = 1000;
    public int hp = 1000;
    public int maxmn = 1000;
    public int mn = 1000;

    public float size = 1;
    public float weight = 1;


    public int pb = 100;
    public int fb = 100;
    public int ib = 100;
    public int vb = 100;

    public int pr = 10;
    public int fr = 10;
    public int ir = 10;
    public int vr = 10;

    public int pPen = 0;
    public int fPen = 0;
    public int iPen = 0;
    public int vPen = 0;

    public int pPenPer = 0;
    public int fPenPer = 0;
    public int iPenPer = 0;
    public int vPenPer = 0;

    public int ms = 2;
    public int searchRange = 7;
    void Start()
    {
        state = GetComponent<UnitState>();
        statusBar =GetComponentInChildren<StatusBar>();
    }

  

    public void ReceiveDmg(int dmg)
    {
        hp -= dmg;
        statusBar.HpRefresh();
        if (hp <= 0) Death();
    }

    void Death()
    {
        hp = 0;

        // ���R���C�_�[�S��������
        Collider2D[] cols = GetComponentsInChildren<Collider2D>();
        foreach (var col in cols)
        {
            col.enabled = false;
        }

        state.NextPos = transform.position;
        // ���̉��o�R���[�`���J�n
        StartCoroutine(DeathAnimation());
    }

    IEnumerator DeathAnimation()
    {
        // BodySprite��T���āA�Q������
        var body = GetComponentInChildren<BodySprite>();
        if (body != null)
        {
            body.transform.rotation = Quaternion.Euler(0, 0, 90);
        }

        // �SSpriteRenderer���t�F�[�h�A�E�g
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

        // ���S�ɏ����ďI��
        Destroy(gameObject);
    }


}
