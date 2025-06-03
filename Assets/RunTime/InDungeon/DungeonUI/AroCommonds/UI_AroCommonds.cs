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

    GameObject selectedAro;
    UnitState selectedState;
    WalkActor selectedWalkActor;

    bool isSettingAro = false;

    private void Start()
    {
        walk_free.onValueChanged.AddListener(_ => ReturnAroCommond());
        chase_run.onValueChanged.AddListener(_ => ReturnAroCommond());
        search_ignore.onValueChanged.AddListener(_ => ReturnAroCommond());
        follow_fixed.onValueChanged.AddListener(_ => ReturnAroCommond());
        MainCam = Camera.main;
    }

    private void Update()
    {
        ClickNextPos();
        FollowCam();
    }

    void ClickNextPos()
    {
        if (Input.GetMouseButtonDown(0) && selectedAro)
        {
            // UIè„ÇæÇ¡ÇΩÇÁÉXÉãÅ[
            if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
                return;

            Vector3 screenPos = Input.mousePosition;
            screenPos.z = Camera.main.nearClipPlane; // 2DÇ»ÇÁ z ÇÕå≈íËÇ≈OK

            Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
            worldPos.z = 0f; // 2DÇæÇ©ÇÁ z=0 Ç…ÇµÇ∆Ç≠

            selectedWalkActor.TargetPos = worldPos;
        }
    }

    void FollowCam()
    {
        if (follow_fixed.isOn && selectedAro)
        {
            Vector3 pos = selectedAro.transform.position;
            pos.z = MainCam.transform.position.z;
            MainCam.transform.position = pos;
        }
    }

    public void SetSelectedAro(GameObject aro)
    {
        selectedAro = aro;
        selectedState = selectedAro.GetComponentInChildren<UnitState>();
        selectedWalkActor = selectedAro.GetComponentInChildren<WalkActor>();

        isSettingAro = true;

        walk_free.isOn = selectedState.Walk_Free;
        chase_run.isOn = selectedState.Combat_Run;
        search_ignore.isOn = selectedState.Search_Ignore;

        isSettingAro = false;
    }

    public void ReturnAroCommond()
    {

        if (isSettingAro) return;

        selectedState.Walk_Free = walk_free.isOn;
        selectedState.Combat_Run = chase_run.isOn;
        selectedState.Search_Ignore = search_ignore.isOn;
        Debug.Log($"{selectedAro},{walk_free.isOn},{chase_run.isOn},{search_ignore.isOn},{follow_fixed.isOn}");
    }
}
