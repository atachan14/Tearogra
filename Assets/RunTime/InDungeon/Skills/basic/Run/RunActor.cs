using UnityEngine;

public class RunActor : BaseSkillActor
{
    Vector3 TargetPos;


    public override void Execute()
    {
        ExeSync();
    }

    protected override void ActSync()
    {
        //NextPos–³Œø‰»B
        state.NextPos = unit.transform.position;
        //TargetPos‚Ì”½‘Î‚ğŒü‚­
        TargetPos = checker.TargetUnit.transform.position;
        UpdateAngleAwayTarget(TargetPos);

        //Œü‚¢‚Ä‚é•ûŒü‚ÉˆÚ“®B
        unit.transform.position += AngleToDir() * unitParams.ms * (1 + skillParams.Get(ParamType.bonusValue)) * Time.deltaTime;
    }
}
