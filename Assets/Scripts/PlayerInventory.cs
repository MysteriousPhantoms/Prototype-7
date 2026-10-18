using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public bool hasAxe;
    public bool hasPickaxe;

    public int wood;

    public TextMeshProUGUI woodText;
    public Image woodIcon;

    private void Start()
    {
        woodText.gameObject.SetActive(false);
        woodIcon.gameObject.SetActive(false);
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
}
