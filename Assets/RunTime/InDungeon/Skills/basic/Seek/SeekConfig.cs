using UnityEngine;

public class SeekConfig : BaseSkillConfig
{
    protected override void InitParamMap()
    {
        base.InitParamMap(); // ���ʃf�t�H���g�l

        configMap[ParamType.bonusValue] = 0.2f;
    }
}
