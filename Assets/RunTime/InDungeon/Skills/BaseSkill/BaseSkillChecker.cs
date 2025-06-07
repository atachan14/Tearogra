using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BaseSkillChecker : MonoBehaviour, IRequireChecker
{
    protected Unit unit;
    protected UnitState state;
    protected UnitParams unitParams;

    protected SkillParams skillParams;
    protected CircleCollider2D col;

    public List<ISkillActor> CanState { get; set; } = new();
    public List<GameObject> TargetList { get; set; } = new();
    public GameObject TargetUnit { get; set; }
    public Vector3 TargetPos { get; set; }

    protected virtual void Start()
    {
        CacheReferences();
        SetupCanState();
        SetupColliderRange();
    }

    protected virtual void CacheReferences()
    {
        unit = GetComponentInParent<Unit>();
        state = GetComponentInParent<UnitState>();
        unitParams = GetComponentInParent<UnitParams>();

        skillParams = GetComponent<SkillParams>();
        col = GetComponent<CircleCollider2D>();
    }
    protected virtual void SetupCanState()
    {
        AddCanState<CombatActor>();
    }

    protected virtual void SetupColliderRange()
    {
        col.radius = skillParams.colRange;
    }

    public virtual bool Check()
    {
        return false;
    }
    

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"LayerMask.LayerToName(other.gameObject.layer):{LayerMask.LayerToName(other.gameObject.layer)}");
        TargetList.Add(other.gameObject);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        TargetList.Remove(other.gameObject);
    }


    //↓ヘルパーメソッドたち↓
    protected void AddCanState<T>() where T : ISkillActor
    {
        var skill = state.GetComponentInChildren<T>();
        if (skill != null)
            CanState.Add(skill);
        else
            Debug.LogWarning($"[BaseSkillChecker] {typeof(T).Name} not found on unit");
    }

    public GameObject GetClosest()
    {
        return TargetList.OrderBy(u => Vector3.Distance(unit.transform.position, u.transform.position)).FirstOrDefault();


    }
}
