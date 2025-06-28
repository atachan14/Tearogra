using System.ComponentModel.Design.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class NextPosMarker : MonoBehaviour
{
    SpriteRenderer sr;
    UnitState state;
    Color tempColor;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        state = GetComponentInParent<UnitState>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = state.NextPos;

        tempColor = sr.color;

        if (Vector3.Distance(transform.position, state.transform.position) < 0.2f)
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
