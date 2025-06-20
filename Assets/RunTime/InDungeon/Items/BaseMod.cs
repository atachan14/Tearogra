using UnityEngine;


public enum ModParamType
{
    // Frame
    front,
    main,
    back,


    // Require
    colRange,
    cd,
    targetCount,

    // AttackCollision
    acFrame,
    acLength,
    acWidth,
    acSpeed,

    // Other
    actNum,
    buff,
    debuff,
    spValue,

    // Damage
    pd,
    fd,
    id,
    ed,

    // Penetration
    pPen,
    fPen,
    iPen,
    ePen,

    // PenetrationPercent
    pPenPer,
    fPenPer,
    iPenPer,
    ePenPer

}

public enum ModOperationType
{
    Multiply, Add, Subtract, Set
}

public class BaseMod : MonoBehaviour
{
    [SerializeField] ModParamType target;
    [SerializeField] ModOperationType operation;
    [SerializeField] float value;

    public virtual void ExportParams(SkillParams s)
    {
        float original = GetTargetValue(s);
        float modified = ApplyOperation(original);
        SetTargetValue(s, modified);
    }
    float GetTargetValue(SkillParams s)
    {
        return target switch
        {
            ModParamType.front => s.front,
            ModParamType.main => s.main,
            ModParamType.back => s.back,

            ModParamType.colRange => s.colRange,
            ModParamType.cd => s.cd,
            ModParamType.targetCount => s.targetCount,

            ModParamType.acFrame => s.acFrame,
            ModParamType.acLength => s.acLength,
            ModParamType.acWidth => s.acWidth,
            ModParamType.acSpeed => s.acSpeed,

            ModParamType.actNum => s.actNum,
            ModParamType.buff => s.buff,
            ModParamType.debuff => s.debuff,
            ModParamType.spValue => s.spValue,

            ModParamType.pd => s.pd,
            ModParamType.fd => s.fd,
            ModParamType.id => s.id,
            ModParamType.ed => s.ed,

            ModParamType.pPen => s.pPen,
            ModParamType.fPen => s.fPen,
            ModParamType.iPen => s.iPen,
            ModParamType.ePen => s.ePen,

            ModParamType.pPenPer => s.pPenPer,
            ModParamType.fPenPer => s.fPenPer,
            ModParamType.iPenPer => s.iPenPer,
            ModParamType.ePenPer => s.ePenPer,

            _ => 0f
        };
    }
    float ApplyOperation(float original)
    {
        return operation switch
        {
            ModOperationType.Add => original + value,
            ModOperationType.Subtract => original - value,
            ModOperationType.Multiply => original * value,
            ModOperationType.Set => value,
            _ => original,
        };
    }

    void SetTargetValue(SkillParams s, float v)
    {
        switch (target)
        {
            case ModParamType.front: s.front = v; break;
            case ModParamType.main: s.main = v; break;
            case ModParamType.back: s.back = v; break;

            case ModParamType.colRange: s.colRange = v; break;
            case ModParamType.cd: s.cd = v; break;
            case ModParamType.targetCount: s.targetCount = v; break;

            case ModParamType.acFrame: s.acFrame = v; break;
            case ModParamType.acLength: s.acLength = v; break;
            case ModParamType.acWidth: s.acWidth = v; break;
            case ModParamType.acSpeed: s.acSpeed = v; break;

            case ModParamType.actNum: s.actNum = v; break;
            case ModParamType.buff: s.buff = v; break;
            case ModParamType.debuff: s.debuff = v; break;
            case ModParamType.spValue: s.spValue = v; break;

            case ModParamType.pd: s.pd = v; break;
            case ModParamType.fd: s.fd = v; break;
            case ModParamType.id: s.id = v; break;
            case ModParamType.ed: s.ed = v; break;

            case ModParamType.pPen: s.pPen = v; break;
            case ModParamType.fPen: s.fPen = v; break;
            case ModParamType.iPen: s.iPen = v; break;
            case ModParamType.ePen: s.ePen = v; break;

            case ModParamType.pPenPer: s.pPenPer = v; break;
            case ModParamType.fPenPer: s.fPenPer = v; break;
            case ModParamType.iPenPer: s.iPenPer = v; break;
            case ModParamType.ePenPer: s.ePenPer = v; break;
        }
    }
}

