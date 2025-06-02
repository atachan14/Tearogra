using UnityEngine;

public class BaseSkillChecker : MonoBehaviour,IRequireChecker
{
    protected UnitState state;
    public Vector3 TargetPos { get; set; }
    public GameObject TargetUnit { get; set; }

    protected virtual void Start()
    {
        state = GetComponentInParent<UnitState>();
        TargetPos = state.transform.position;
    }

    public virtual bool Check()
    {
        Debug.Log("BaseRequireChecker");

        return false;
    }
}
