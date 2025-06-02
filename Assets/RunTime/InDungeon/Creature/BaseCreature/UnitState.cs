using UnityEngine;
using UnityEngine.UIElements;



public class UnitState : MonoBehaviour
{

    public ISkillActor ActionSkill ;
    [SerializeField] MonoBehaviour debug_ActionSkill;
    public Vector3 angle = Vector3.zero;

    public bool Walk_Free { get; set; } = true;
    public bool Combat_Run { get; set; } = true;
    public bool Search_Ignore { get; set; } = true;

    void Start()
    {
        ActionSkill = (ISkillActor)GetComponentInChildren<FreeActor>();
        Debug.Log($"ActionSkill:{(MonoBehaviour)ActionSkill}");
        //ActionMode = GetComponentInChildren<UnitCommonds>().Walk_Free ? Walk : ActionModeCode.Free;

    }

    // Update is called once per frame
    void Update()
    {
        debug_ActionSkill = (MonoBehaviour)ActionSkill;
        UpdateActionMode();
    }

    void UpdateActionMode()
    {
        //if (ActionMode == ActionModeCode.Free
        //    && cmds.Walk_Free)
        //{
        //    ActionMode = ActionModeCode.Walk;
        //    return;
        //}

        //if (ActionMode == ActionModeCode.Walk
        //    && !cmds.Walk_Free)
        //{
        //    ActionMode = ActionModeCode.Free;
        //    return;
        //}

        //if (ActionMode == ActionModeCode.Run
        //    && cmds.Combat_Run)
        //{
        //    ActionMode = ActionModeCode.Combat;
        //    return;
        //}

        //if (ActionMode == ActionModeCode.Combat
        //    && !cmds.Combat_Run)
        //{
        //    ActionMode = ActionModeCode.Run;
        //    return;
        //}



    }
}
