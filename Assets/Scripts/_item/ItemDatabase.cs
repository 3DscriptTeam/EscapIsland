using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance;
    public List<Item> items = new List<Item>();

    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start()
    {
        Add("GreenPotion", 1, 500, "green potion", ItemType.Consumption);
    }

    void Add(string itemName, int itemValue, int itemPrice, string itemDesc, ItemType itemType)
    {
        items.Add(new Item(itemName, itemValue, itemPrice, itemDesc, itemType, Resources.Load<Sprite>("ItemImages/" + itemName)));
    }
}