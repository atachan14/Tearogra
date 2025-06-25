using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_DmgGraphRow : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] Sprite defaultIcon;

    [Header("バー（それぞれ横幅をscale.xで調整）")]
    [SerializeField] Image physicBar;
    [SerializeField] Image fireBar;
    [SerializeField] Image iceBar;
    [SerializeField] Image voltBar;

    [Header("味方へのDmgやTank量")]
    [SerializeField] Image physicBarToFriend;
    [SerializeField] Image fireBarToFriend;
    [SerializeField] Image iceBarToFriend;
    [SerializeField] Image voltBarToFriend;

    [Header("敵への（敵からの）ダメージ表示")]
    [SerializeField] TMP_Text totalText;
    [SerializeField] TMP_Text elementText;

    private Dictionary<Element, Image> barImages = new();
    private Dictionary<Element, Image> barToFriendImages = new();

    [SerializeField] private RectTransform dmgBar;
    private float baseBarLength;

    void Awake()
    {
        barImages[Element.Physic] = physicBar;
        barImages[Element.Fire] = fireBar;
        barImages[Element.Ice] = iceBar;
        barImages[Element.Volt] = voltBar;

        barToFriendImages[Element.Physic] = physicBarToFriend;
        barToFriendImages[Element.Fire] = fireBarToFriend;
        barToFriendImages[Element.Ice] = iceBarToFriend;
        barToFriendImages[Element.Volt] = voltBarToFriend;

        foreach (var pair in barImages)
        {
            if (pair.Value != null)
                pair.Value.color = ElementColor.GetColor(pair.Key);
        }
        foreach (var pair in barToFriendImages)
        {
            if (pair.Value != null)
                pair.Value.color = ElementColor.GetColor(pair.Key) * new Color(1f, 1f, 1f, 0.5f);
        }

        baseBarLength = dmgBar.rect.width;
    }

    public void SetIcon(Unit aro)
    {
        icon.sprite = aro.GetComponentInChildren<IconSprites>().AroSelectorIcon;
    }

    public int GetTotalDamage(Dictionary<(int? dealer, int? tank), Dictionary<Element, int>> damageLog, DamageViewType viewType)
    {
        int id = transform.GetSiblingIndex();
        int total = 0;
        foreach (var kvp in damageLog)
        {
            int? dealer = kvp.Key.dealer;
            int? tank = kvp.Key.tank;

            if ((viewType == DamageViewType.Dealer && dealer == id) ||
                (viewType == DamageViewType.Tank && tank == id))
            {
                foreach (var dmg in kvp.Value.Values)
                    total += dmg;
            }
        }
        return total;
    }

    public void UpdateBarLengthRatio(int maxTotalDamage, Dictionary<(int? dealer, int? tank), Dictionary<Element, int>> damageLog, int myId, DamageViewType viewType)
    {
        Dictionary<Element, int> mainBar = new();
        Dictionary<Element, int> toFriendBar = new();
        foreach (Element e in System.Enum.GetValues(typeof(Element)))
        {
            mainBar[e] = 0;
            toFriendBar[e] = 0;
        }

        foreach (var kvp in damageLog)
        {
            int? dealer = kvp.Key.dealer;
            int? tank = kvp.Key.tank;

            if (viewType == DamageViewType.Dealer)
            {
                if (dealer == myId)
                {
                    foreach (var eDmg in kvp.Value)
                    {
                        if (tank.HasValue && tank.Value < UI_DmgGraph.Instance.rows.Length)
                            toFriendBar[eDmg.Key] += eDmg.Value;
                        else
                            mainBar[eDmg.Key] += eDmg.Value;
                    }
                }
            }
            else if (viewType == DamageViewType.Tank)
            {
                if (tank == myId)
                {
                    foreach (var eDmg in kvp.Value)
                    {
                        if (dealer.HasValue && dealer.Value < UI_DmgGraph.Instance.rows.Length)
                            toFriendBar[eDmg.Key] += eDmg.Value;
                        else
                            mainBar[eDmg.Key] += eDmg.Value;
                    }
                }
            }
        }

        int totalDmg = 0;
        foreach (var val in mainBar.Values) totalDmg += val;
        foreach (var val in toFriendBar.Values) totalDmg += val;

        float ratio = Mathf.Clamp01((float)totalDmg / maxTotalDamage);
        float totalBarLength = baseBarLength * ratio;

        foreach (var e in mainBar.Keys)
        {
            float mainLen = totalDmg > 0 ? totalBarLength * mainBar[e] / totalDmg : 0;
            float subLen = totalDmg > 0 ? totalBarLength * toFriendBar[e] / totalDmg : 0;
            SetBarLength(barImages[e].rectTransform, mainLen);
            SetBarLength(barToFriendImages[e].rectTransform, subLen);
        }

        if (totalText != null)
            totalText.text = $"{totalDmg}";

        if (elementText != null)
            elementText.text = GenerateElementDamageText(mainBar);
    }

    void SetBarLength(RectTransform rect, float width)
    {
        var size = rect.sizeDelta;
        size.x = width;
        rect.sizeDelta = size;
    }

    string GenerateElementDamageText(Dictionary<Element, int> elementDmg)
    {
        System.Text.StringBuilder sb = new();
        foreach (var pair in elementDmg)
        {
            if (pair.Value <= 0) continue;
            Color c = ElementColor.GetColor(pair.Key);
            string hex = ColorUtility.ToHtmlStringRGB(c);
            sb.Append($"<color=#{hex}>{pair.Value}</color>");
        }
        return sb.ToString();
    }

    public void ReceiveDeath()
    {
        icon.sprite = defaultIcon;
    }
}