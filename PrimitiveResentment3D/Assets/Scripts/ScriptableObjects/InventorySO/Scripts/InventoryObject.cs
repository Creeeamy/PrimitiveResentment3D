using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : ScriptableObject
{

    public List<InventorySlot> itemContainer = new List<InventorySlot>();

    public void AddItem(ItemObject _item, int _amount)
    {
        bool hasItem = false;

        for(int i = 0; i < itemContainer.Count; i++)
        {
            if(itemContainer[i].item == _item)
            {
                itemContainer[i].AddAmount(_amount);
                hasItem = true;
                break;
            }
        }
    }

}


[System.Serializable]
public class InventorySlot
{
    public ItemObject item;
    public int amount;
    public InventorySlot(ItemObject _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }

}
