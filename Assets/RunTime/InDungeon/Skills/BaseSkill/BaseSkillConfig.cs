using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ParamValue
{
    public ParamType type;
    public float value;
}

public class BaseSkillConfig : MonoBehaviour
{
    protected Dictionary<ParamType, float> configMap = new();

    // 継承先がここをoverrideして追加パラメーターを定義
    protected virtual void InitParamMap()
    {
        // 共通のデフォルト値をここに書く
        configMap[ParamType.acLength] = 1f;
        configMap[ParamType.acWidth] = 1f;
        configMap[ParamType.acSpeed] = 1f;
        configMap[ParamType.acWeight] = 1f;
    }

    protected virtual void Awake()
    {
        InitParamMap();
    }

    public Dictionary<ParamType, float> GetConfigMap()
    {
        return new Dictionary<ParamType, float>(configMap);
    }
}
