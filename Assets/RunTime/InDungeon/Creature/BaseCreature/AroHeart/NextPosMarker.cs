using System.ComponentModel.Design.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class NextPosMarker : MonoBehaviour
{
    SpriteRenderer sr;
    UnitCommonds cmds;
    Vector3 NextPos;
    Color tempColor;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        cmds = GetComponentInParent<UnitCommonds>();
    }

    // Update is called once per frame
    void Update()
    {
        
        NextPos = cmds.NextPos;
        transform.position = NextPos;

        tempColor = sr.color;

        if (Vector3.Distance(transform.position, cmds.transform.position) < 0.2f)
        {
            tempColor.a = 0f; // Š®‘S‚É“§–¾
        }
        else
        {
            tempColor.a = 1f; // Š®‘S‚É•s“§–¾
        }

        sr.color = tempColor;

    }
}
