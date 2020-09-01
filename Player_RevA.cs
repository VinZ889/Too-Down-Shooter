using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public InventoryObject Inventory;
    private Sprite icon;

    private void Awake()
    {
        //icon = GetComponent<Item>();
    }

    public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<ItemPickup>();
        if (item)
        {
            Inventory.AddItem(item.item, 1, icon);
            Destroy(other.gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        Inventory.list.Clear();
    }
}
