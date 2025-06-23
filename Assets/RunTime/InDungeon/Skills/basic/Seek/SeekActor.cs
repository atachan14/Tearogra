using UnityEngine;
using static UnityEngine.ParticleSystem;

public class SeekActor : BaseSkillActor
{
    Vector3 TargetPos { get; set; }
    public override void Execute()
    {
        ExeSync();
    }

    protected override void ActSync()
    {
        //TargetPos‚ğŒü‚­
        TargetPos = checker.TargetUnit.transform.position;
        UpdateAngleToTarget(TargetPos);

        //‹——£‚ª‹ß‚·‚¬‚½‚ç‘Ò‹@
        //‹ß‚·‚¬‚È‚©‚Á‚½‚çŒü‚¢‚Ä‚é•ûŒü‚ÉˆÚ“®B
        if (Vector3.Distance(TargetPos, unit.transform.position) < 0.5f)
        {
            return;
        }
        else
        {
            unit.transform.position += AngleToDir() * unitParams.ms * (1 + skillParams.Get(ParamType.bonusValue)) * Time.deltaTime;
        }
    }
}
