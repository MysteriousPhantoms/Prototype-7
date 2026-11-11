using UnityEngine;
using UnityEngine.InputSystem;

public class DevMenu : MonoBehaviour
{
    [Header("UI")]
    public GameObject devMenuUI;

    [Header("Teleport Points")]
    public Transform startPoint;
    public Transform caveEntrance;
    public Transform caveExit;
    public Transform upgradeStation;
    public Transform catLocation;
    public Transform finalBridge;

    [Header("Items")]
    public ItemData wood;
    public ItemData stone;
    public ItemData iron;
    public ItemData gold;
    public ItemData diamond;

    [Header("Tools")]
    public ItemData woodAxe;
    public ItemData stoneAxe;
    public ItemData ironAxe;
    public ItemData goldAxe;
    public ItemData diamondAxe;

    public ItemData woodPickaxe;
    public ItemData stonePickaxe;
    public ItemData ironPickaxe;
    public ItemData goldPickaxe;
    public ItemData diamondPickaxe;

    private void Update()
    {
        if (Keyboard.current.f1Key.wasPressedThisFrame)
        {
            devMenuUI.SetActive(
                !devMenuUI.activeSelf);
        }
    }

    private GameObject Player()
    {
        return GameObject.FindGameObjectWithTag("Player");
    }

    public void TeleportTo(Transform location)
    {
        GameObject player = Player();

        if (player == null || location == null)
            return;

        player.transform.position =
            location.position;
    }

    public void GiveItem(ItemData item)
    {
        if (InventoryManager.Instance == null)
            return;

        InventoryManager.Instance.AddItem(item);
    }

    public void GiveWood()
    {
        for (int i = 0; i < 50; i++)
            GiveItem(wood);
    }

    public void GiveStone()
    {
        for (int i = 0; i < 50; i++)
            GiveItem(stone);
    }

    public void GiveIron()
    {
        for (int i = 0; i < 50; i++)
            GiveItem(iron);
    }

    public void GiveGold()
    {
        for (int i = 0; i < 50; i++)
            GiveItem(gold);
    }

    public void GiveDiamond()
    {
        for (int i = 0; i < 50; i++)
            GiveItem(diamond);
    }

    public void GiveAllTools()
    {
        GiveItem(woodAxe);
        GiveItem(stoneAxe);
        GiveItem(ironAxe);
        GiveItem(goldAxe);
        GiveItem(diamondAxe);

        GiveItem(woodPickaxe);
        GiveItem(stonePickaxe);
        GiveItem(ironPickaxe);
        GiveItem(goldPickaxe);
        GiveItem(diamondPickaxe);
    }

    public void CollectAllPetals()
    {
        if (CosmicPetalManager.Instance == null)
            return;

        CosmicPetalManager.Instance.petalsCollected = 5;
    }

    public void SpawnFlower()
    {
        if (CosmicPetalManager.Instance == null)
            return;

        CosmicPetalManager.Instance.cosmicFlower
            .SetActive(true);
    }
}
