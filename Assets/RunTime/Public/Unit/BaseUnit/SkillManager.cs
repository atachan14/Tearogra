using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkillManager
    : MonoBehaviour
{
    List<BaseSkillChecker> checkerList;
    [SerializeField] GameObject basicSkills;
    [SerializeField] GameObject advancedSkills;
    private void Start()
    {
        var advList = advancedSkills.GetComponentsInChildren<BaseSkillChecker>();
        var basicList = basicSkills.GetComponentsInChildren<BaseSkillChecker>();
        checkerList = advList.Concat(basicList).ToList(); 
    }

    // Update is called once per frame
    void Update()
    {
        foreach (BaseSkillChecker checker in checkerList)
        {
            if (checker.Check())
            {
                BaseSkillActor actor = checker.GetComponent<BaseSkillActor>();
                actor.Execute();
                return;
            }
        }
    }
}
