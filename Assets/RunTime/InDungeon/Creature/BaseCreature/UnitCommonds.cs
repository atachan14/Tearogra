using UnityEngine;

public class UnitCommonds : MonoBehaviour
{
    public bool Walk_Free { get; set; } = true;
    public bool Combat_Run { get; set; } = true;
    public bool Search_Ignore { get; set; } = true;
    
    public Vector3 NextPos { get; set; }

    UnitParameter parameter;
    UnitState state;
   
    void Start()
    {
        parameter = GetComponent<UnitParameter>();
        state = GetComponent<UnitState>();
        NextPos = transform.position;
    }

    void Update()
    {
        Walk();
    }

    

    void Walk()
    {
        if (state.ActionMode == ActionModeCode.Walk
             && Vector3.Distance(transform.position, NextPos) > 0.1f)
        {
            Vector3 dir = (NextPos - transform.position).normalized;

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);

            transform.position += dir * parameter.ms * Time.deltaTime;
        }
    }

}
