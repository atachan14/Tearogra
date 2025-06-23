using UnityEngine;

public class StatusBar : MonoBehaviour
{
    BaseUnitParams unitParams;
    [SerializeField] private Transform hpValue;
    [SerializeField] private Transform mnValue;

    private Vector3 originalHPScale;
    private Vector3 originalMNScale;

    void Awake()
    {
        // 初期スケールを記録（横幅の基準）
        if (hpValue != null) originalHPScale = hpValue.localScale;
        if (mnValue != null) originalMNScale = mnValue.localScale;
    }
    

    void Start()
    {
        unitParams = GetComponentInParent<BaseUnitParams>();
    }


    public void HpRefresh()
    {
        float hpRate = (float)unitParams.hp / unitParams.maxhp;

        SetHPRate(hpRate);
       
    }
    public void SetHPRate(float rate)
    {
        rate = Mathf.Clamp01(rate);
        if (hpValue != null)
            hpValue.localScale = new Vector3(originalHPScale.x * rate, originalHPScale.y, originalHPScale.z);
    }

    public void MnRefresh()
    {
        float mnRate = (float)unitParams.mn / unitParams.maxmn;
        SetMnRate(mnRate);
    }
    public void SetMnRate(float rate)
    {
        rate = Mathf.Clamp01(rate);
        if (mnValue != null)
            mnValue.localScale = new Vector3(originalMNScale.x * rate, originalMNScale.y, originalMNScale.z);
    }
}
