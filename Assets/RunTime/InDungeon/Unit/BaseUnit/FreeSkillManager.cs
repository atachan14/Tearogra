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
        checkerList = GetComponentsInChildren<IRequireChecker>();
    }


    void Update()
    {
        if (state.ActionSkill is FreeActor
            || state.ActionSkill is WalkActor)
        {
            foreach (IRequireChecker checker in checkerList) 
            {
                if (checker.Check())
                {
                    ISkillActor actor = ((MonoBehaviour)checker).GetComponent<ISkillActor>();
                    actor.Execute();
                }
            }
        }
    }
}
