
using UnityEngine;
public class UI_DmgGraph : MonoBehaviour
{
    public static UI_DmgGraph Instance;
    UI_DmgGraphRow[] rows;
    int maxTotalDamage = 1; // 最初は1で割り算ゼロ除け対策

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        rows = GetComponentsInChildren<UI_DmgGraphRow>();
    }

    public void ReportDamage(int aroId, Element e, int dmg)
    {
        // 1. 該当行にダメージ追加
        rows[aroId].AddDamage(e, dmg);

        // 2. 最大ダメージ再計算
        RecalculateMaxTotalDamage();

        // 3. 全Row更新（グラフ比率反映）
        RefreshAllRows();
    }

    void RecalculateMaxTotalDamage()
    {
        maxTotalDamage = 1;
        foreach (var row in rows)
        {
            maxTotalDamage = Mathf.Max(maxTotalDamage, row.GetTotalDamage());
        }
    }

    void RefreshAllRows()
    {
        foreach (var row in rows)
        {
            row.UpdateBarLengthRatio(maxTotalDamage);
        }
    }
}
