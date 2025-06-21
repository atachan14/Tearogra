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

    // �p���悪������override���Ēǉ��p�����[�^�[���`
    protected virtual void InitParamMap()
    {
        // ���ʂ̃f�t�H���g�l�������ɏ���
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
