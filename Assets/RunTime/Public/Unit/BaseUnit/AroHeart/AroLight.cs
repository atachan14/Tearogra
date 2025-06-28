using UnityEngine;
using UnityEngine.Rendering.Universal;

public class AroLight : MonoBehaviour
{
    Light2D aroLight;
    float lightRange = 9;
    private const float decayRatePerSecond = 1f / 60f;

    public bool IsOn {  get; private set; }


    void Start()
    {
        aroLight = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsOn)
        {
            if (lightRange <= 0f) return;

            aroLight.enabled = true;

            lightRange -= decayRatePerSecond * Time.deltaTime;
            lightRange = Mathf.Max(0f, lightRange); // •‰‚Ì’l‚É‚È‚ç‚È‚¢‚æ‚¤‚É

            aroLight.pointLightOuterRadius = lightRange;
        }
        else
        {
            aroLight.enabled = false;
        }
    }

    public void StartBreak()
    {
        IsOn = false;
    }

    public void FloorSetup()
    {
        IsOn = true;
    }
}
