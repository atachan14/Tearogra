using System.Collections.Generic;
using UnityEngine;

public class StartPosManager : MonoBehaviour
{
    public static StartPosManager Instance { get; set; }

    List<Transform> children = new();

    private void Awake()
    {
        Instance = this;
    }


    public void AroSetPosition()
    {

        foreach (Transform child in transform)
        {
            children.Add(child);
        }


        foreach (Unit aro in AroManager.Instance.AroDict.Values)
        {
            if (!aro) continue;
            Debug.Log(aro.AroId);
            aro.transform.position = children[(int)aro.AroId].transform.position;
            aro.state.NextPos = aro.transform.position;

            if (aro.AroId < 2)
            {
                aro.state.Angle = -90;
            }
            else
            {
                aro.state.Angle = -91;
            }
            aro.gameObject.SetActive(true);
            //aro.GetComponentInChildren<AroLight>()?.StartBreak();


        }

    }
}