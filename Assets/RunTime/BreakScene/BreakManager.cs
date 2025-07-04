using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BreakManager : MonoBehaviour
{
    public static BreakManager instance;
    [SerializeField] Light2D breakLight;
    [SerializeField] Image breakUI;
    private void Awake()
    {
        instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ArosSetup();
        StartCoroutine(BreakStart());
    }

    void ArosSetup()
    {
        foreach (Unit aro in AroManager.Instance.AroDict.Values)
        {
            if(!aro) continue;

            aro.transform.position = BreakPosManager.Instance.posList[(int)aro.AroId].transform.position;

            if (aro.AroId < 2)
            {
                aro.state.Angle = -90;
            }
            else 
            {
                aro.state.Angle = -91;
            }
 

        }
        PlayerData.Instance.BreakSetup();

    }

    IEnumerator BreakStart()
    {
        yield return StartCoroutine(BreakLightUp());
        yield return StartCoroutine(OpenUI());
    }

    IEnumerator BreakLightUp()
    {
        float duration = 2f;
        float time = 0f;
        float startRadius = 0f;
        float targetRadius = 10f; // �K�v�ɉ����Ē������ĂˁI

        breakLight.pointLightOuterRadius = startRadius;

        while (time < duration)
        {
            float t = time / duration;
            breakLight.pointLightOuterRadius = Mathf.Lerp(startRadius, targetRadius, t);
            time += Time.deltaTime;
            yield return null;
        }

        breakLight.pointLightOuterRadius = targetRadius; // �ŏI�I�Ƀs�b�^��
    }


    IEnumerator OpenUI()
    {
        RectTransform rt = breakUI.GetComponent<RectTransform>();

        Vector2 startPos = new Vector2(rt.anchoredPosition.x, 700f);
        Vector2 endPos = new Vector2(rt.anchoredPosition.x, -50f);

        float duration = 1f;
        float time = 0f;

        rt.anchoredPosition = startPos;

        while (time < duration)
        {
            float t = time / duration;
            rt.anchoredPosition = Vector2.Lerp(startPos, endPos, t);
            time += Time.deltaTime;
            yield return null;
        }

        rt.anchoredPosition = endPos; // �Ō�ɂ҂�����
    }

    public void NextFloor()
    {
        SceneManager.LoadScene("FloorScene");
    }


}
