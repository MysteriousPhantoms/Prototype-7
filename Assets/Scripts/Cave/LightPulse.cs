using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightPulse : MonoBehaviour
{
    public Light2D targetLight;

    public float minIntensity = 0.5f;
    public float maxIntensity = 2f;

    public float minRadius = 1.5f;
    public float maxRadius = 2.5f;

    public float speed = 3f;

    private void Update()
    {
        if (targetLight == null)
            return;

        float pulse =
            Mathf.PingPong(
                Time.time * speed,
                1f);

        targetLight.intensity =
            Mathf.Lerp(
                minIntensity,
                maxIntensity,
                pulse);

        targetLight.pointLightOuterRadius =
            Mathf.Lerp(
                minRadius,
                maxRadius,
                pulse);
    }
}
