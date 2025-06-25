using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
using Toggle = UnityEngine.UI.Toggle;

public class UI_ArosSelectorField : MonoBehaviour
{
    public Unit Aro { get; private set; }

    

    [SerializeField] Image outLine;
    [SerializeField] Image InnerShadow;
    [SerializeField] Image aroIconImage;

    [SerializeField] Toggle toggle;
    [SerializeField] Color onColor = Color.green;
    [SerializeField] Color offColor = Color.gray;
    [SerializeField] Color lastColor = Color.red;


    [SerializeField] Sprite defaultSprite;



    void Start()
    {
        UpdateOutLineColor();
        toggle.onValueChanged.AddListener(_ => OnValueChanged());
    }

    void OnValueChanged()
    {
        UpdateOutLineColor();
        SendSelectedAro();
    }

    void SendSelectedAro()
    {
        if (toggle.isOn)
        {
            UI_ArosSelector.Instance.AddSelectedAro(Aro);
        }

        if (!toggle.isOn)
        {
            UI_ArosSelector.Instance.RemoveSelectedAro(Aro);
        }
    }
    public void UpdateOutLineColor()
    {
        outLine.color = toggle.isOn ? onColor : offColor;
    }

    public void UpdateLastAro()
    {
        outLine.color = lastColor;
    }

    public void SetAro(Unit aro)
    {
        if (!aro) return;

        Aro = aro;
        aroIconImage.sprite = Aro.GetComponentInChildren<IconSprites>().AroSelectorIcon;

        Aro.GetComponentInChildren<AroShadow>()
            .GetComponent<SpriteRenderer>()
            .color = InnerShadow.color;

        Aro.GetComponentInChildren<NextPosMarker>()
           .GetComponent<SpriteRenderer>()
           .color = InnerShadow.color;

        toggle.enabled = true;
    }



    public void ReceiveDeath()
    {
        Aro = null;
        toggle.isOn = false;
        toggle.enabled = false;
        StartCoroutine(DeathAnimation());
    }

    IEnumerator DeathAnimation()
    {
        float totalDuration = 4f;
        float halfDuration = totalDuration / 2f;

        // イメージの色取得（透明度だけ操作）
        Color startColor = aroIconImage.color;

        // ① フェードアウト（2秒）
        for (float t = 0; t < halfDuration; t += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(1f, 0f, t / halfDuration);
            aroIconImage.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            yield return null;
        }

        // 念のため完全に透明にする
        aroIconImage.color = new Color(startColor.r, startColor.g, startColor.b, 0f);

        // スプライト差し替え
        aroIconImage.sprite = defaultSprite;

        // ② フェードイン（2秒）
        for (float t = 0; t < halfDuration; t += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(0f, 1f, t / halfDuration);
            aroIconImage.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            yield return null;
        }

        // 念のため完全に表示
        aroIconImage.color = new Color(startColor.r, startColor.g, startColor.b, 1f);
    }


}
