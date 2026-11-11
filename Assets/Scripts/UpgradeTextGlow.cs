using TMPro;
using UnityEngine;

public class UpgradeTextGlow : MonoBehaviour
{
    public TextMeshProUGUI textUI;

    private void Update()
    {
        float glow =
            Mathf.PingPong(
                Time.time * 3f,
                1f);

        textUI.color =
            Color.Lerp(
                Color.red,
                Color.yellow,
                glow);
    }
}
