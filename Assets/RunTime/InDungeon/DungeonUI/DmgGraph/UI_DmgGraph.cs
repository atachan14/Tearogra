
using UnityEngine;
public class UI_DmgGraph : MonoBehaviour
{
    public static UI_DmgGraph Instance;
    public UI_DmgGraphRow[] rows { get; set; }
    int maxTotalDamage = 1; // �ŏ���1�Ŋ���Z�[�������΍�

    private void Awake()
    {
        Instance = this;
        rows = GetComponentsInChildren<UI_DmgGraphRow>();
    }

    void Start()
    {
        
    }

    public void SetupIcon(Unit[] aroList)
    {
        for (int i = 0; i < aroList.Length; i++)
        {
            rows[i].SetIcon(aroList[i]);
        }
    }
    public void ReportDamage(int aroId, Element e, int dmg)
    {
        // 1. �Y���s�Ƀ_���[�W�ǉ�
        rows[aroId].AddDamage(e, dmg);

        // 2. �ő�_���[�W�Čv�Z
        RecalculateMaxTotalDamage();

        // 3. �SRow�X�V�i�O���t�䗦���f�j
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
