using UnityEngine;

public class FoundConfig : BaseSkillConfig
{
    public override void ExportParams()
    {
        skillParams.front = 1f;      //発見時の硬直
    }
}
