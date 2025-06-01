using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_AroCommonds : MonoBehaviour
{
    [SerializeField] Toggle walk_free;
    [SerializeField] Toggle chase_run;
    [SerializeField] Toggle search_ignore;
    [SerializeField] Toggle follow_fixed;
    GameObject selectedAro;
    AroCommonds selectedAroCommonds;

    bool isSettingAro = false;

    private void Start()
    {
        walk_free.onValueChanged.AddListener(_ => ReturnAroCommond());
        chase_run.onValueChanged.AddListener(_ => ReturnAroCommond());
        search_ignore.onValueChanged.AddListener(_ => ReturnAroCommond());
        follow_fixed.onValueChanged.AddListener(_ => ReturnAroCommond());
    }

    public void SetSelectedAro(GameObject aro)
    {
        isSettingAro = true;

        selectedAro = aro;
        selectedAroCommonds = selectedAro.GetComponentInChildren<AroCommonds>();
        walk_free.isOn = selectedAroCommonds.Walk_Free;
        chase_run.isOn = selectedAroCommonds.Chase_Run;
        search_ignore.isOn = selectedAroCommonds.Search_Ignore;
        follow_fixed.isOn = selectedAroCommonds.Follow_Fixed;

        isSettingAro = false;
    }

    public void ReturnAroCommond()
    {

        if (isSettingAro) return;

        selectedAroCommonds.Walk_Free = walk_free.isOn;
        selectedAroCommonds.Chase_Run = chase_run.isOn;
        selectedAroCommonds.Search_Ignore = search_ignore.isOn;
        selectedAroCommonds.Follow_Fixed = follow_fixed.isOn;
        Debug.Log($"{selectedAro},{walk_free.isOn},{chase_run.isOn},{search_ignore.isOn},{follow_fixed.isOn}");
    }
}
