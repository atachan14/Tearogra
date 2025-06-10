using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkillManager
    : MonoBehaviour
{
    List<IRequireChecker> checkerList;
    [SerializeField] GameObject basicSkills;
    [SerializeField] GameObject advancedSkills;
    private void Start()
    {
        var advList = advancedSkills.GetComponentsInChildren<IRequireChecker>();
        var basicList = basicSkills.GetComponentsInChildren<IRequireChecker>();
        checkerList = advList.Concat(basicList).ToList(); 
    }

    // Update is called once per frame
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
