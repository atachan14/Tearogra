using UnityEngine;

public class CombatConfig : BaseSkillConfig
{

    protected override void InitParamMap()
    {
        base.InitParamMap(); // ���ʃf�t�H���g�l

        configMap[ParamType.msBonus] = 0.2f;
    }
}
