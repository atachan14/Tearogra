using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public enum DamageViewType { Dealer, Tank }

public class UI_DmgGraph : MonoBehaviour
{
    public static UI_DmgGraph Instance;
    public UI_DmgGraphRow[] rows { get; set; }
    int maxTotalDamage = 1;
    public DamageViewType viewType = DamageViewType.Dealer;

    [Header("タブ切替ボタン（任意）")]
    [SerializeField] private Button dealerTabButton;
    [SerializeField] private Button tankTabButton;

    public Dictionary<(int? dealer, int? tank), Dictionary<Element, int>> damageLog = new();

    private void Awake()
    {
        Instance = this;
        rows = GetComponentsInChildren<UI_DmgGraphRow>();

        if (dealerTabButton != null)
            dealerTabButton.onClick.AddListener(() => SetViewType(DamageViewType.Dealer));

        if (tankTabButton != null)
            tankTabButton.onClick.AddListener(() => SetViewType(DamageViewType.Tank));
    }

    public void SetupIcon(Unit[] aroList)
    {
        for (int i = 0; i < aroList.Length; i++)
            rows[i].SetIcon(aroList[i]);
    }

    public void ReportDamage(Element e, int? dealerId, int? tankId, int dmg)
    {
        var key = (dealerId, tankId);
        if (!damageLog.TryGetValue(key, out var elementDict))
        {
            elementDict = new();
            damageLog[key] = elementDict;
        }

        if (!elementDict.ContainsKey(e))
            elementDict[e] = 0;
        elementDict[e] += dmg;

        RecalculateMaxTotalDamage();
        RefreshAllRows();
    }

    void RecalculateMaxTotalDamage()
    {
        maxTotalDamage = 1;
        foreach (var row in rows)
            maxTotalDamage = Mathf.Max(maxTotalDamage, row.GetTotalDamage(damageLog, viewType));
    }

    void RefreshAllRows()
    {
        for (int i = 0; i < rows.Length; i++)
        {
            rows[i].UpdateBarLengthRatio(maxTotalDamage, damageLog, i, viewType);
        }
    }

    public void SetViewType(DamageViewType type)
    {
        viewType = type;
        RecalculateMaxTotalDamage();
        RefreshAllRows();
    }
}