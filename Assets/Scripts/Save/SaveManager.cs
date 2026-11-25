using UnityEngine;
using UnityEngine.InputSystem;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    private string savePath;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        savePath =
            Application.persistentDataPath +
            "/save.json";
    }

    private void Update()
    {
        if (Keyboard.current.f5Key.wasPressedThisFrame)
        {
            SaveGame();
        }
    }

    public void SaveGame()
    {
        SaveData data =
            new SaveData();

        data.currentScene =
            UnityEngine.SceneManagement
            .SceneManager
            .GetActiveScene()
            .name;

        GameObject player =
            GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            data.playerX =
                player.transform.position.x;

            data.playerY =
                player.transform.position.y;
        }

        if (CosmicPetalManager.Instance != null)
        {
            data.petalsCollected =
                CosmicPetalManager.Instance.petalsCollected;
        }

        foreach (InventorySlot slot in
            InventoryManager.Instance.inventorySlots)
        {
            if (slot.currentItem == null)
                continue;

            InventorySlotData slotData =
                new InventorySlotData();

            slotData.itemName =
                slot.currentItem.item.itemName;

            slotData.amount =
                slot.currentItem.count;

            data.inventory.Add(slotData);
        }

        string json =
            JsonUtility.ToJson(
                data,
                true);

        Debug.Log("Saving To: " + savePath);

        File.WriteAllText(
            savePath,
            json);

        Debug.Log("Game Saved");
    }
}
