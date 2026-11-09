using TMPro;
using UnityEngine;
using System.Collections;

public class CosmicPetalManager : MonoBehaviour
{
    public static CosmicPetalManager Instance;

    [Header("Petals")]
    public int petalsCollected;
    public int petalsRequired = 5;

    [Header("Flower")]
    public GameObject cosmicFlower;

    [Header("UI")]
    public CanvasGroup petalsUI;
    public TextMeshProUGUI petalsText;

    private bool flowerSpawned;

    private Coroutine fadeRoutine;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        petalsUI.alpha = 0f;

        UpdateText();
    }

    public void CollectPetal()
    {
        petalsCollected++;

        UpdateText();

        ShowUI();

        if (!flowerSpawned &&
            petalsCollected >= petalsRequired)
        {
            flowerSpawned = true;

            cosmicFlower.SetActive(true);

            CosmicFlowerGlow glow =
                cosmicFlower.GetComponent<CosmicFlowerGlow>();

            if (glow != null)
            {
                glow.BeginGlow();
            }
        }
    }

    private void UpdateText()
    {
        petalsText.text =
            "Petals: " +
            petalsCollected +
            "/" +
            petalsRequired;
    }

    private void ShowUI()
    {
        if (fadeRoutine != null)
        {
            StopCoroutine(fadeRoutine);
        }

        fadeRoutine =
            StartCoroutine(FadeRoutine());
    }

    private IEnumerator FadeRoutine()
    {
        petalsUI.alpha = 1f;

        yield return new WaitForSeconds(3f);

        while (petalsUI.alpha > 0f)
        {
            petalsUI.alpha -= Time.deltaTime;

            yield return null;
        }

        petalsUI.alpha = 0f;
    }
}
