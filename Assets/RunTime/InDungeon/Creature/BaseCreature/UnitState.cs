using UnityEngine;
using UnityEngine.UIElements;



public class UnitState : MonoBehaviour
{

    public ISkillActor ActionSkill;
    [SerializeField] MonoBehaviour debug_ActionSkill;
    public float Angle { get; set; } = -91;

    public bool Walk_Free { get; set; } = true;
    public bool Combat_Run { get; set; } = true;
    public bool Search_Ignore { get; set; } = true;

    void Start()
    {
        ActionSkill = (ISkillActor)GetComponentInChildren<FreeActor>();
        Debug.Log($"ActionSkill:{(MonoBehaviour)ActionSkill}");

    }

    // Update is called once per frame
    void Update()
    {
        debug_ActionSkill = (MonoBehaviour)ActionSkill;
    }

}
