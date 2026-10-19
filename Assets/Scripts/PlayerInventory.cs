using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [Header("Tools")]
    public bool hasAxe;
    public bool hasPickaxe;

    [Header("Resources")]
    public int wood;
    public int stone;

    [Header("Wood UI")]
    public TextMeshProUGUI woodText;
    public Image woodIcon;

    [Header("Stone UI")]
    public TextMeshProUGUI stoneText;
    public Image stoneIcon;

    private void Start()
    {
        woodText.gameObject.SetActive(false);
        woodIcon.gameObject.SetActive(false);

        stoneText.gameObject.SetActive(false);
        stoneIcon.gameObject.SetActive(false);
    }

    public void AddWood(int amount)
    {
        wood += amount;

        woodText.text = wood.ToString();

        if (!woodIcon.gameObject.activeSelf)
        {
            woodIcon.gameObject.SetActive(true);
            woodText.gameObject.SetActive(true);
        }
    }

    public void AddStone(int amount)
    {
        stone += amount;

        stoneText.text = stone.ToString();

        if (!stoneIcon.gameObject.activeSelf)
        {
            stoneIcon.gameObject.SetActive(true);
            stoneText.gameObject.SetActive(true);
        }
    }

    public bool UseWood(int amount)
    {
        if (wood < amount)
            return false;

        wood -= amount;
        woodText.text = wood.ToString();

        return true;
    }
}
