using UnityEngine;

public class CosmicFlowerGlow : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private bool glowActive;

    private void Awake()
    {
        spriteRenderer =
            GetComponent<SpriteRenderer>();
    }

    public void BeginGlow()
    {
        glowActive = true;
    }

    private void Update()
    {
        if (!glowActive)
            return;

        float glow =
            Mathf.PingPong(
                Time.time,
                0.5f);

        spriteRenderer.color =
            Color.Lerp(
                Color.white,
                Color.cyan,
                glow);
    }
}
