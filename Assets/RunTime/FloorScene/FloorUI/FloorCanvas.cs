using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FloorCanvas : MonoBehaviour
{
    public static FloorCanvas Instance;
    [SerializeField] CanvasGroup group;
    private void Awake()
    {
        Instance = this;
    }

    public void FloorSetup()
    {
        UI_ArosSelector.Instance.FloorSetup();
        UI_DmgGraph.Instance.FloorSetup();

    }

    public IEnumerator FadeOutUI()
    {
        group.blocksRaycasts = true;

        float duration = 1.5f;
        float time = 0f;

        while (time < duration)
        {
            group.alpha = Mathf.Lerp(1f, 0f, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        group.alpha = 0f;
    }

}
