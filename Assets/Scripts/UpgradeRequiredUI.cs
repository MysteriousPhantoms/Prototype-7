using TMPro;
using UnityEngine;
using System.Collections;

public class UpgradeRequiredUI : MonoBehaviour
{
    public static UpgradeRequiredUI Instance;

    public CanvasGroup canvasGroup;
    public TextMeshProUGUI messageText;

    private Coroutine fadeRoutine;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowMessage(string message)
    {
        messageText.text = message;

        if (fadeRoutine != null)
        {
            StopCoroutine(fadeRoutine);
        }

        fadeRoutine = StartCoroutine(FadeRoutine());
    }

    private IEnumerator FadeRoutine()
    {
        canvasGroup.alpha = 1f;

        yield return new WaitForSeconds(2f);

        while (canvasGroup.alpha > 0f)
        {
            canvasGroup.alpha -= Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = 0f;
    }
}
