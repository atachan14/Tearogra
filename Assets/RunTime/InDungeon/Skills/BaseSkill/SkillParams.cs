using System.Collections.Generic;
using UnityEngine;

public class SkillParams : MonoBehaviour
{
    private BaseSkillConfig config;
    private BaseSkillChecker checker;
    private Dictionary<ParamType, float> paramMap = new();

    protected void Start()
    {
        CacheReferences();
        SetupSkill();
    }

    void CacheReferences()
    {
        config = GetComponent<BaseSkillConfig>();
        checker = GetComponent<BaseSkillChecker>();
    }

    void SetupSkill()
    {
        ImportConfig();          // ← これ1本で完結する構造に
        checker.SetupChecker();
    }

    public void ImportConfig()
    {
        var map = config.GetConfigMap();
        foreach (var kv in map)
        {
            paramMap[kv.Key] = kv.Value;
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
            Debug.LogWarning($"ParamType [{type}] はSkillParamsに存在しません");
            return;
        }

        paramMap[type] += value;
    }

    public bool Has(ParamType type)
    {
        return paramMap.ContainsKey(type);
    }
}
