using System.Collections.Generic;
using UnityEngine;



public class BaseSkillConfig : MonoBehaviour
{
    protected Dictionary<ParamType, float> configMap = new();

    protected virtual void Awake()
    {
        InitParamMap();
    }

    protected virtual void InitParamMap()
    {
        configMap[ParamType.acLength] = 1f;
        configMap[ParamType.acWidth] = 1f;
        configMap[ParamType.acSpeed] = 1f;
        configMap[ParamType.acWeight] = 1f;
    }

    public virtual void Apply(Dictionary<ParamType, float> paramMap)
    {
        foreach (var kv in configMap)
        {
            paramMap[kv.Key] = kv.Value;
        }
    }
}
