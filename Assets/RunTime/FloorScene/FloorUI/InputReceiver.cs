using UnityEngine;
using UnityEngine.EventSystems;

public class InputReceiver : MonoBehaviour
{
    [SerializeField] private float dragThreshold = 10f;
    [SerializeField] private MainCamController mainCam;
    [SerializeField] private UI_ArosSelector aroSelector;
    private Vector3 mouseDownPos;
    private bool isDragging = false;

    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            mouseDownPos = Input.mousePosition;
            isDragging = false;
        }

        if (Input.GetMouseButton(0))
        {
            if (!isDragging && (Input.mousePosition - mouseDownPos).sqrMagnitude > dragThreshold * dragThreshold)
            {
                isDragging = true;
            }

            if (isDragging)
            {
                mainCam.Scroll(Input.mousePosition - mouseDownPos);
                mouseDownPos = Input.mousePosition; // çXêVÇµÇƒääÇÁÇ©Ç…
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (!isDragging)
            {
                SetNextPos(Input.mousePosition);
            }

            isDragging = false;
        }
    }
    void SetNextPos(Vector3 pos)
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(pos);
        worldPos.z = 0f;

        foreach (Unit aro in aroSelector.SelectedAros)
        {
            aro.GetComponent<UnitState>().NextPos = worldPos;
        }
    }
}

