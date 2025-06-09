using UnityEngine;
using UnityEngine.UIElements;



public class UnitState : MonoBehaviour
{
    public ISkillActor ActionSkill { get; set; }
    [SerializeField] MonoBehaviour debug_ActionSkill;
    public bool IsAlert { get; set; }


    public Vector3 NextPos;
    public float Angle { get; set; } = -91;

    public bool Walk_Free { get; set; } = true;
    public bool Combat_Run { get; set; } = true;
    public bool Search_Ignore { get; set; } = true;

    void Start()
    {
        ActionSkill = (ISkillActor)GetComponentInChildren<FreeActor>();
        NextPos = transform.position;

    }

    void Update()
    {
        debug_ActionSkill = (MonoBehaviour)ActionSkill;

      
    }

}
