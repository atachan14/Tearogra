using System.Collections;
using UnityEngine;

public class FreeActor : MonoBehaviour,ISkillActor
{
    public IEnumerator Exe()
    {
        yield return null;
    }
}
