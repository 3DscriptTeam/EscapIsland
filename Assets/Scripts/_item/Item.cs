﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ItemType //장 비 소모 기타 아이템 구분
{
    Equipment,//장비
    Consumption,//소모
    Misc//기타
}
[System.Serializable]

public class Item
{

    public string itemName;
    public int itemValue;
    public int itemPrice;
    public string itemDesc;
    public ItemType itemType;
    public Sprite itemImage;

    public Item(string _itemName, int _itemValue, int _itemPrice, string _itemDesc, ItemType _itemType, Sprite _itemImage)
    {
        itemName = _itemName;
        itemValue = _itemValue;
        itemPrice = _itemPrice;
        itemDesc = _itemDesc;
        itemType = _itemType;
        itemImage = _itemImage;
    }

    public Item()
    {

    }
}