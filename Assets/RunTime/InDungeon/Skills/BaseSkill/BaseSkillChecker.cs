using System.Collections.Generic;
using UnityEngine;

public class BaseSkillChecker : MonoBehaviour, IRequireChecker
{
    protected UnitState state;

    public List<GameObject> TargetList = new();
    public Vector3 TargetPos { get; set; }
    public GameObject TargetUnit { get; set; }

    protected virtual void Start()
    {
        state = GetComponentInParent<UnitState>();
        TargetPos = state.transform.position;
        SetupColliderRange();
    }

    protected virtual void SetupColliderRange()
    {

    }

    public virtual bool Check()
    {
        Debug.Log("BaseRequireChecker‚ªoverride‚³‚ê‚Ä‚Ü‚¹‚ñ");

        return false;
    }

    void OnTriggerEnter(Collider other)
    {
        TargetList.Add(other.gameObject);
    }

    void OnTriggerExit(Collider other)
    {
        TargetList.Remove(other.gameObject);
    }
}
