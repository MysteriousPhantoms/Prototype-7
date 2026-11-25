using System;
using System.Collections.Generic;

[Serializable]
public class SaveData
{
    public string currentScene;

    public float playerX;
    public float playerY;

    public int petalsCollected;

    public List<InventorySlotData> inventory =
        new List<InventorySlotData>();
}

[Serializable]
public class InventorySlotData
{
    public string itemName;

    public int amount;
}