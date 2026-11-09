using UnityEngine;

public class FlowerInventory : MonoBehaviour
{
    public static FlowerInventory Instance;

    public bool hasCosmicFlower;

    private void Awake()
    {
        Instance = this;
    }
}
