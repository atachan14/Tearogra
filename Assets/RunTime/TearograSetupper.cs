using UnityEngine;

public class TearograSetupper : MonoBehaviour
{

    void Awake()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
        Time.fixedDeltaTime = 1f / 60f;
        Screen.SetResolution(1280, 720, false);
        Application.runInBackground = true;
        Time.timeScale = 1f;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
