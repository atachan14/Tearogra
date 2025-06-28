using System.Collections.Generic;
using UnityEngine;

public class SkillParams : MonoBehaviour
{
    private Dictionary<ParamType, float> paramMap = new();

    private BaseSkillConfig config;
    private BaseSkillChecker checker;

   

    void CacheReferences()
    {
        config = GetComponent<BaseSkillConfig>();
        checker = GetComponent<BaseSkillChecker>();
    }

    public void SetupSkill()
    {
        CacheReferences();
        config.Apply(paramMap); // �� dict�ɒ��ڏ����l���������݁I
        ImportMod(); //
        checker.FloorSetup();
    }

    public void ImportMod()
    {
        var mods = GetComponentsInChildren<BaseMod>();
        foreach (var mod in mods)
        {
            mod.Apply(paramMap);
        }
    }

    public float Get(ParamType type)
    {
        return paramMap.TryGetValue(type, out var value) ? value : 0f;
    }

    public void Set(ParamType type, float value)
    {
        paramMap[type] = value;
    }

    public void Add(ParamType type, float value)
    {
        if (!paramMap.ContainsKey(type))
        {
            Debug.LogWarning($"ParamType [{type}] ��SkillParams�ɑ��݂��܂���");
            return;
        }

        paramMap[type] += value;
    }

    public bool Has(ParamType type)
    {
        return paramMap.ContainsKey(type);
    }
}
