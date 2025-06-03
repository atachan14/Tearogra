using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Metadata;

public class FreeSkillManager : MonoBehaviour
{
    UnitState state;
    IRequireChecker[] checkerList;

    private void Start()
    {
        state = GetComponentInParent<UnitState>();
        SetupSkillList();
    }

    void SetupSkillList()
    {
        checkerList = GetComponentsInChildren<IRequireChecker>();


    }

    void Update()
    {
        if (state.ActionSkill is FreeActor)
        {
            foreach (IRequireChecker checker in checkerList) 
            {
                if (checker.Check())
                {
                    ISkillActor actor = ((MonoBehaviour)checker).GetComponent<ISkillActor>();
                    if (actor != null)
                    {
                        actor.Execute();
                    }
                    else 
                    {
                        Debug.Log($"actor‚ª‚ ‚è‚Ü‚¹‚ñ. checker:{checker}");
                    }
                }
            }
        }
    }
}
