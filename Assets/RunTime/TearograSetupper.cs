using UnityEngine;

public class TearograSetupper : MonoBehaviour
{

    void Awake()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
        Time.fixedDeltaTime = 1f / 60f;
        Screen.SetResolution(1440, 720, false);
        Application.runInBackground = true;
        Time.timeScale = 1f;
       



    }

   




}
