using System.Collections.Generic;
using UnityEngine;

public class StartPosManager : MonoBehaviour
{
    List<Transform> children = new();
    void Start()
    {
        foreach (Transform child in transform)
        {
            children.Add(child);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
