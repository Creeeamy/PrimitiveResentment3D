using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTest : MonoBehaviour
{
    private InventoryManager inventoryManager;
    private InventoryObject _inventory;

    private void Start()
    {
        inventoryManager = InventoryManager.instance;
        _inventory = inventoryManager.inventory;
    }

    private void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<Item>();

        if (item)
        {
            Debug.Log("Touched");
            _inventory.AddItem(item.heldItem, 1);
            Destroy(other.gameObject);
        }
    }
}
