using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Metadata;

public class AdvancedSkillManager : MonoBehaviour
{
    IRequireChecker[] checkerList;

    private void Start()
    {
        checkerList = GetComponentsInChildren<IRequireChecker>();
    }

    void Update()
    {
        foreach (IRequireChecker checker in checkerList)
        {
            if (checker.Check())
            {
                ISkillActor actor = ((MonoBehaviour)checker).GetComponent<ISkillActor>();
                actor.Execute();
                return;
            }
        }
    }
}
