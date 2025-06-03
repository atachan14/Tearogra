using System.ComponentModel.Design.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class NextPosMarker : MonoBehaviour
{
    SpriteRenderer sr;
    WalkChecker walkChecker;
    Color tempColor;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        walkChecker = GetComponentInParent<Unit>().GetComponentInChildren<WalkChecker>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = walkChecker.TargetPos;

        tempColor = sr.color;

        if (Vector3.Distance(transform.position, walkChecker.transform.position) < 0.2f)
        {
            tempColor.a = 0f; // ���S�ɓ���
        }
        else
        {
            tempColor.a = 1f; // ���S�ɕs����
        }

        sr.color = tempColor;

    }
}
