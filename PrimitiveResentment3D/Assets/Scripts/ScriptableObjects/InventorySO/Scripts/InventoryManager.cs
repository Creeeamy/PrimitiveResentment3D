using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventoryObject inventory;
    private static InventoryManager _inventoryInstance;


    public static InventoryManager instance
    {

        get
        {
            return _inventoryInstance;
        }

    }

    private void Awake()
    {
        if (_inventoryInstance != null && _inventoryInstance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _inventoryInstance = this;
        }
    }

    private void OnApplicationQuit()
    {
        inventory.itemContainer.Clear();
    }

}
