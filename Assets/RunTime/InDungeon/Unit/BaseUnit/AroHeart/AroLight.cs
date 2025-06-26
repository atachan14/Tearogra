using UnityEngine;
using UnityEngine.Rendering.Universal;

public class AroLight : MonoBehaviour
{
    UnitParams uParams;
    Light2D spotLight;
    float lightRange = 8;
    private const float decayRatePerSecond = 1f / 60f;


    void Start()
    {
        spotLight = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lightRange <= 0f) return;

        lightRange -= decayRatePerSecond * Time.deltaTime;
        lightRange = Mathf.Max(0f, lightRange); // •‰‚Ì’l‚É‚È‚ç‚È‚¢‚æ‚¤‚É

        spotLight.pointLightOuterRadius = lightRange;
    }
}
