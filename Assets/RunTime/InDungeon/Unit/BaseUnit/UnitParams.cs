using System.Collections;
using UnityEngine;

public enum Element
{
    Physic,
    Fire,
    Ice,
    Volt
}

[System.Serializable]
public class ElementTable<T>
{
    public T Physic;
    public T Fire;
    public T Ice;
    public T Volt;

    public ElementTable() { }

    public ElementTable(T defaultValue)
    {
        Physic = defaultValue;
        Fire = defaultValue;
        Ice = defaultValue;
        Volt = defaultValue;
    }

    public T this[Element e]
    {
        get => e switch
        {
            Element.Physic => Physic,
            Element.Fire => Fire,
            Element.Ice => Ice,
            Element.Volt => Volt,
            _ => default
        };
        set
        {
            switch (e)
            {
                case Element.Physic: Physic = value; break;
                case Element.Fire: Fire = value; break;
                case Element.Ice: Ice = value; break;
                case Element.Volt: Volt = value; break;
            }
        }
    }
}

public class UnitParams : MonoBehaviour
{
    Unit unit;
    UnitState state;
    StatusBar statusBar;

    

    public int maxhp = 1000;
    public int hp = 1000;
    public int maxmn = 1000;
    public int mn = 1000;

    public float size = 1;
    public float weight = 1f;

    [SerializeField] public ElementTable<int> attackBonus = new();
    [SerializeField] public ElementTable<int> resist = new();
    [SerializeField] public ElementTable<int> penFlat = new();
    [SerializeField] public ElementTable<int> penPercent = new();

    public int ms = 2;
    public int lightRange = 7;

    void Awake()
    {
        SetupParams();
    }

    protected void SetupParams()
    {
        // ämíËìIÇ»èâä˙ílÇÇ±Ç±Ç≈Ç‘ÇøçûÇﬁ
        attackBonus = new ElementTable<int>(100);
        resist = new ElementTable<int>(10);
        penFlat = new ElementTable<int>(0);
        penPercent = new ElementTable<int>(0);
    }

    private void Start()
    {
        unit = GetComponent<Unit>();
        state = GetComponent<UnitState>();
        statusBar = GetComponentInChildren<StatusBar>();
    }

    public int GetResist(Element e) => resist[e];

    public void ReportDmg(int dmg)
    {
        hp -= dmg;
        statusBar.HpRefresh();

        if (hp <= 0) unit.Death();
    }

   
}
