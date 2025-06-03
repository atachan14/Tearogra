using UnityEngine;

public class FoundChecker : BaseSkillChecker
{

    public override bool Check()
    {
        return TargetList.Count > 0;
    }

    protected override void Start()
    {

        base.Start();
    }
}
