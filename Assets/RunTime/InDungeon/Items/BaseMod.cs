using UnityEngine;

using System;
using System.Collections.Generic;

public enum ModOperationType
{
    Add,
    Multiply,
}

[Serializable]
public struct ParamModifier
{
    public ParamType type;
    public float value;
    public ModOperationType operation;
}




public class BaseMod : BaseItem
{
    [SerializeField] private List<ParamModifier> modifiers = new();

    public virtual void Apply(Dictionary<ParamType, float> paramMap)
    {
        foreach (var mod in modifiers)
        {
            if (!paramMap.ContainsKey(mod.type)) continue;

            float current = paramMap[mod.type];
            float result = mod.operation switch
            {
                ModOperationType.Add => current + mod.value,
                ModOperationType.Multiply => current * mod.value,
                _ => current
            };

            paramMap[mod.type] = result;
        }
    }
}
