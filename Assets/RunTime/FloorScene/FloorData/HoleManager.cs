using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
                if (h != hole) h.Close(); // Close()‚ÍŽ©ìŠÖ”
            }
        }
    }

    public void EnteredHole(Unit aro)
    {

        if (!enteredAros.Contains(aro))
            enteredAros.Add(aro);

        if (enteredAros.Count >= AroManager.Instance.aroCount)
        {
            StartCoroutine(FloorClear()); // ‘Sˆõ“ü‚Á‚½
        }
    }

    IEnumerator FloorClear()
    {


        yield return StartCoroutine(FloorCanvas.Instance.FadeOutUI());

        SceneManager.LoadScene("BreakScene");

        Debug.Log("Floor Cleared!");
    }

  

  
}
