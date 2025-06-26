using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleManager : MonoBehaviour
{
    public static HoleManager Instance;

    private List<Hole> holes = new();
    private Hole selectedHole;
    private HashSet<Unit> enteredAros = new();

    public void RegisterHole(Hole h) { if (!holes.Contains(h)) holes.Add(h); }

    public bool IsLocked => selectedHole != null;


    private void Awake()
    {
        Instance = this;
    }

    public void ShutterHole(Hole hole)
    {
        if (selectedHole == null)
        {
            selectedHole = hole;
            foreach (var h in holes)
            {
                if (h != hole) h.Close(); // Close()は自作関数
            }
        }
    }

    public void EnteredHole(Unit aro)
    {

        if (!enteredAros.Contains(aro))
            enteredAros.Add(aro);

        if (enteredAros.Count >= AroManager.Instance.aroCount)
        {
            StartCoroutine(FloorClear()); // 全員入った
        }
    }

    IEnumerator FloorClear()
    {

        Dui_Manager.Instance.gameObject.SetActive(false);

        RevealAros();
        
        BreakArea.instance.gameObject.SetActive(true);

        yield return StartCoroutine(FadeOutFloorData());


        
        Debug.Log("Floor Cleared!");
    }

    void RevealAros()
    {
        foreach (var aro in AroManager.Instance.AroDict.Values)
        {
            if (aro != null)
                aro.gameObject.SetActive(true);
        }
    }

    IEnumerator FadeOutFloorData()
    {
        FloorManager fm = GetComponentInParent<FloorManager>();
        SpriteRenderer[] srsList = fm.GetComponentsInChildren<SpriteRenderer>();

        float duration = 3.0f; // フェードアウト時間
        float time = 0f;

        // 初期カラーを保持
        Dictionary<SpriteRenderer, Color> originalColors = new();
        foreach (var sr in srsList)
            originalColors[sr] = sr.color;

        while (time < duration)
        {
            float t = time / duration;
            foreach (var sr in srsList)
            {
                if (sr == null) continue;
                Color c = originalColors[sr];
                c.a = Mathf.Lerp(1f, 0f, t);
                sr.color = c;
            }
            time += Time.deltaTime;
            yield return null;
        }

        // 最終的に完全に透明にしてから破壊
        foreach (var sr in srsList)
        {
            if (sr == null) continue;
            Color c = originalColors[sr];
            c.a = 0f;
            sr.color = c;
        }

        Destroy(fm.gameObject);
    }
}
