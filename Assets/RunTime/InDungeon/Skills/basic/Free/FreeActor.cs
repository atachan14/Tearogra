using System.Collections;
using UnityEngine;

public class FreeActor : BaseSkillActor
{
    public override void Execute()
    {
        state.ActionSkill = this;
    }

}
