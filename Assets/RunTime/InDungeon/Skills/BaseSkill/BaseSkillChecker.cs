using System.Collections.Generic;
using UnityEngine;

public class BaseSkillChecker : MonoBehaviour, IRequireChecker
{
    protected UnitState state;
    protected UnitParams unitParams;
    protected SkillParams skillParams;
    protected CircleCollider2D col;

    public List<ISkillActor> canState = new();

    public List<GameObject> TargetList = new();
    public GameObject TargetUnit { get; set; }
    public Vector3 TargetPos { get; set; }

    protected virtual void Start()
    {
        state = GetComponentInParent<UnitState>();
        unitParams = GetComponentInParent<UnitParams>();

        skillParams = GetComponent<SkillParams>();
        col = GetComponent<CircleCollider2D>();

        TargetPos = state.transform.position;
        SetupCanState();
        SetupColliderRange();
        
    }
    protected virtual void SetupCanState()
    {
        AddCanState<CombatActor>();
    }

    protected virtual void SetupColliderRange()
    {
        col.radius = skillParams.actRange;
    }

    public virtual bool Check()
    {

        return false;
    }

    



    protected void AddCanState<T>() where T : ISkillActor
    {
        var skill = GetComponentInParent<T>();
        if (skill != null)
            canState.Add(skill);
        else
            Debug.LogWarning($"[BaseSkillChecker] {typeof(T).Name} not found on unit");
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
}
