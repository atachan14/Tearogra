using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_AroCommonds : MonoBehaviour
{
    public static UI_AroCommonds Instance;

    [SerializeField] Toggle Seek_Ignore;
    [SerializeField] Toggle chase_run;
    [SerializeField] Toggle search_ignore;
    [SerializeField] Toggle follow_fixed;

    Camera MainCam;
   
    bool isSettingAro = false;

    private void Awake()
    {
        Instance = this;
    }


    private void Start()
    {
        Seek_Ignore.onValueChanged.AddListener(_ => AssingAroCommond());
        chase_run.onValueChanged.AddListener(_ => AssingAroCommond());
        search_ignore.onValueChanged.AddListener(_ => AssingAroCommond());
        follow_fixed.onValueChanged.AddListener(_ => AssingAroCommond());
        MainCam = Camera.main;
    }

    private void Update()
    {
        if (follow_fixed.isOn && UI_ArosSelector.Instance.LastSelectedAro)
        {
            FollowCam();
        }
    }

    void FollowCam()
    {

        Vector3 pos = UI_ArosSelector.Instance.LastSelectedAro.transform.position;
        pos.z = MainCam.transform.position.z;
        MainCam.transform.position = pos;

    }



    public void UpdateSelectedAro(Unit aro)
    {
        if (UI_ArosSelector.Instance.LastSelectedAro == null) return;
        UnitState selectedState = UI_ArosSelector.Instance.LastSelectedAro.GetComponentInChildren<UnitState>();

        isSettingAro = true;

        Seek_Ignore.isOn = selectedState.Seek_Ignore;
        chase_run.isOn = selectedState.Combat_Run;
        search_ignore.isOn = selectedState.Search_Ignore;

        isSettingAro = false;
    }




    public void AssingAroCommond()
    {
        if (isSettingAro) return;

        foreach (Unit aro in UI_ArosSelector.Instance.SelectedAros)
        {
            UnitState state = aro.GetComponent<UnitState>();
            state.Seek_Ignore = Seek_Ignore.isOn;
            state.Combat_Run = chase_run.isOn;
            state.Search_Ignore = search_ignore.isOn;
            Debug.Log($"{aro},{Seek_Ignore.isOn},{chase_run.isOn},{search_ignore.isOn},{follow_fixed.isOn}");
        }

    }
}
