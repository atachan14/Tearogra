using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public enum AlertType
{
    Free,
    Combat,
    Run
}


public class UnitState : MonoBehaviour
{
   
    public List<ISkillActor> SkillState { get; set; } = new();
    [SerializeField] private List<MonoBehaviour> debug_SkillState = new();

    public bool IsAlert { get; set; }

    public AlertType AlertState
    {
        get
        {
            if (!IsAlert) return AlertType.Free;
            return Combat_Run ? AlertType.Combat : AlertType.Run;
        }
    }


    public Vector3 NextPos { get; set; }
    public float Angle { get; set; } = -91;

    public bool Seek_Ignore { get; set; } = true;
    public bool Combat_Run { get; set; } = true;
    public bool Search_Ignore { get; set; } = true;



    public void FloorSetup()
    {
        NextPos = transform.position;
    }

    void Update()
    {
        debug_SkillState = SkillState
        .OfType<MonoBehaviour>()
        .ToList();

    }

}
