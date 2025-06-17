using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class UI_DmgGraphRow : MonoBehaviour
{
    [Header("バー（それぞれ横幅をscale.xで調整）")]
    [SerializeField] Image physicBar;
    [SerializeField] Image fireBar;
    [SerializeField] Image iceBar;
    [SerializeField] Image voltBar;

    [Header("ダメージ表示")]
    [SerializeField] TMP_Text totalText;      // 合計
    [SerializeField] TMP_Text elementText;    // 属性ごとの色付きテキスト

    private Dictionary<Element, int> damageDict = new();
    private Dictionary<Element, Image> barImages = new();

    [SerializeField] private RectTransform dmgBar;
    private float baseBarLength;

    void Awake()
    {
        damageDict[Element.Physic] = 0;
        damageDict[Element.Fire] = 0;
        damageDict[Element.Ice] = 0;
        damageDict[Element.Volt] = 0;

        barImages[Element.Physic] = physicBar;
        barImages[Element.Fire] = fireBar;
        barImages[Element.Ice] = iceBar;
        barImages[Element.Volt] = voltBar;

        // 色の初期設定
        foreach (var pair in barImages)
        {
            if (pair.Value != null)
                pair.Value.color = ElementColor.GetColor(pair.Key);
        }

        baseBarLength = dmgBar.rect.width;
    }

    public void AddDamage(Element element, int dmg)
    {
        if (!damageDict.ContainsKey(element)) return;
        damageDict[element] += dmg;
    }

    public int GetTotalDamage()
    {
        int total = 0;
        foreach (var dmg in damageDict.Values)
            total += dmg;
        return total;
    }

    public void UpdateBarLengthRatio(int maxTotalDamage)
    {
        float ratio = Mathf.Clamp01((float)GetTotalDamage() / maxTotalDamage);
        float totalBarLength = baseBarLength * ratio;

        int totalDmg = GetTotalDamage();
        if (totalDmg <= 0)
        {
            foreach (var img in barImages.Values)
                SetBarLength(img.rectTransform, 0);
        }
        else
        {
            foreach (var pair in barImages)
            {
                Element e = pair.Key;
                Image img = pair.Value;
                float width = totalBarLength * damageDict[e] / totalDmg;
                SetBarLength(img.rectTransform, width);
            }
        }

        if (totalText != null)
            totalText.text = $"{GetTotalDamage()}";

        if (elementText != null)
            elementText.text = GenerateElementDamageText();
    }

    void SetBarLength(RectTransform rect, float width)
    {
        var size = rect.sizeDelta;
        size.x = width;
        rect.sizeDelta = size;
    }

    string GenerateElementDamageText()
    {
        System.Text.StringBuilder sb = new();

        foreach (var pair in damageDict)
        {
            if (pair.Value <= 0) continue;

            Color c = ElementColor.GetColor(pair.Key);
            string hex = ColorUtility.ToHtmlStringRGB(c);
            sb.Append($"<color=#{hex}>{pair.Value}</color>");
        }

        return sb.ToString();
    }


}
