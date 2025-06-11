using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_AroCommonds : MonoBehaviour
{
    [SerializeField] Toggle walk_free;
    [SerializeField] Toggle chase_run;
    [SerializeField] Toggle search_ignore;
    [SerializeField] Toggle follow_fixed;

    Camera MainCam;

    [SerializeField] UI_ArosSelector arosSelector;
    Unit lastSelectedAro;
    UnitState selectedState;

    bool isSettingAro = false;

    private void Start()
    {
        walk_free.onValueChanged.AddListener(_ => AssingAroCommond());
        chase_run.onValueChanged.AddListener(_ => AssingAroCommond());
        search_ignore.onValueChanged.AddListener(_ => AssingAroCommond());
        follow_fixed.onValueChanged.AddListener(_ => AssingAroCommond());
        MainCam = Camera.main;
    }

    private void Update()
    {
        FollowCam();
    }

    void FollowCam()
    {
        if (follow_fixed.isOn && lastSelectedAro)
        {
            Vector3 pos = lastSelectedAro.transform.position;
            pos.z = MainCam.transform.position.z;
            MainCam.transform.position = pos;
        }
    }



    public void UpdateSelectedAro(Unit aro)
    {
        lastSelectedAro = aro;
        selectedState = lastSelectedAro.GetComponentInChildren<UnitState>();

        isSettingAro = true;

        walk_free.isOn = selectedState.Walk_Free;
        chase_run.isOn = selectedState.Combat_Run;
        search_ignore.isOn = selectedState.Search_Ignore;

        isSettingAro = false;
    }

    public void AssingAroCommond()
    {
        if (isSettingAro) return;

        foreach (Unit aro in arosSelector.SelectedAros)
        {
            UnitState state = aro.GetComponent<UnitState>();
            state.Walk_Free = walk_free.isOn;
            state.Combat_Run = chase_run.isOn;
            state.Search_Ignore = search_ignore.isOn;
            Debug.Log($"{aro},{walk_free.isOn},{chase_run.isOn},{search_ignore.isOn},{follow_fixed.isOn}");
        }
        
    }
}
