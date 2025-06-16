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

    void SetupTriggerMatrix()
    {
       
        Physics2D.IgnoreLayerCollision(
        LayerMask.NameToLayer("AroSearcher"),
        LayerMask.NameToLayer("AroHeart"),
        true // Å© ñ≥éãÇ∑ÇÈÇÊÇ§Ç…ê›íË
        );

        Physics2D.IgnoreLayerCollision(
        LayerMask.NameToLayer("GraSearcher"),
        LayerMask.NameToLayer("GraHeart"),
        true // Å© ñ≥éãÇ∑ÇÈÇÊÇ§Ç…ê›íË
        );
    }




}
