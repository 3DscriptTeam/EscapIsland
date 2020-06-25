﻿using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public Transform slot;
    public List<Slot> slotScripts = new List<Slot>();

    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Transform newSlot = Instantiate(slot);
                newSlot.name = "Slot" + (i + 1) + "." + (j + 1);
                newSlot.parent = transform;
                RectTransform slotRect = newSlot.GetComponent<RectTransform>();
                slotRect.anchorMin = new Vector2(0.2f * j + 0.05f, 1 - (0.2f * (i + 1) - 0.05f));
                slotRect.anchorMax = new Vector2(0.2f * (j + 1) - 0.05f, 1 - (0.2f * i + 0.05f));
                slotRect.offsetMin = Vector2.zero;
                slotRect.offsetMax = Vector2.zero;

                slotScripts.Add(newSlot.GetComponent<Slot>());
                newSlot.GetComponent<Slot>().number = i * 5 + j;
            }
        }
        AddItem(0);
        AddItem(1);
    }

    void AddItem(int number)
    {
        for (int i = 0; i < slotScripts.Count; i++)
        {
            if (slotScripts[i].item.itemValue == 0)
            {
                slotScripts[i].item = ItemDatabase.instance.items[number];
                break;
            }
        }
    }
}