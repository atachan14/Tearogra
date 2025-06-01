using UnityEngine;
using UnityEngine.UIElements;

public enum ActionModeCode
{
    Sreep,
    Free,
    Walk,
    Combat,
    Act,
    Run,
}

public class UnitState : MonoBehaviour
{
    UnitCommonds cmds;

    public ActionModeCode ActionMode = ActionModeCode.Free;
    public Vector3 angle = Vector3.zero;


    void Start()
    {
        cmds = GetComponentInChildren<UnitCommonds>();
        ActionMode = GetComponentInChildren<UnitCommonds>().Walk_Free ? ActionModeCode.Walk : ActionModeCode.Free;

    }

    // Update is called once per frame
    void Update()
    {
        UpdateActionMode();
    }

    void UpdateActionMode()
    {
        if (ActionMode == ActionModeCode.Free
            && cmds.Walk_Free)
        {
            ActionMode = ActionModeCode.Walk;
            return;
        }

        if (ActionMode == ActionModeCode.Walk
            && !cmds.Walk_Free)
        {
            ActionMode = ActionModeCode.Free;
            return;
        }

        if (ActionMode == ActionModeCode.Run
            && cmds.Combat_Run)
        {
            ActionMode = ActionModeCode.Combat;
            return;
        }

        if (ActionMode == ActionModeCode.Combat
            && !cmds.Combat_Run)
        {
            ActionMode = ActionModeCode.Run;
            return;
        }



    }
}
