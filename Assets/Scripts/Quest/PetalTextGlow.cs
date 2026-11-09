using TMPro;
using UnityEngine;

public class PetalsTextGlow : MonoBehaviour
{
    public TextMeshProUGUI textUI;

    public Color colorA = Color.white;
    public Color colorB = Color.cyan;

    private void Update()
    {
        float t =
            Mathf.PingPong(
                Time.time,
                1f);

        textUI.color =
            Color.Lerp(
                colorA,
                colorB,
                t);
    }
}
