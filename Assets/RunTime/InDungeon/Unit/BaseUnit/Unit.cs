using UnityEngine;

public class Unit : MonoBehaviour
{
    public void SetupUnit()
    {
        GetComponent<UnitState>().FloorSetup();

        var skillParams = GetComponentsInChildren<SkillParams>();
        foreach (var skill in skillParams)
        {
            skill.SetupSkill();
        }
    }
}
