using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public List<InventorySlot> list = new List<InventorySlot>(); // this inventoryslot is referring to inventory slot under system serializable
   
    //public Button removeButton;
    public void AddItem(ItemObject newItem, int Amount, Sprite icon) // change from Image to Sprite
    {
        bool hasItem = false;
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].item == newItem)
            {
                list[i].AddAmount(Amount);
                hasItem = true;
                break;
            }
        }
        if (!hasItem)
        {
            list.Add(new InventorySlot(newItem, Amount, icon));
        }
    }
}

[System.Serializable]
public class InventorySlot
{
    public ItemObject item;
    public int amount;
    public Sprite icon;// change from Image to Sprite
    
    
    public InventorySlot(ItemObject newItem, int Amount, Sprite Icon) // change from Image to Sprite
    {
        item = newItem;
        amount = Amount;
        icon = Icon;
        //icon.enabled = true;
        //removeButton.interactable = true;
        
    }
    public void AddAmount(int value)
    {
        amount += value;
    }

    public void UseItem()
    {
        item = null;
        icon = null;
        //icon.enabled = false;
        //removeButton.interactable = false;
    }


   /* public void onRemoveButton()
    {
        _Inventory.instance.Remove(item);
    }*/


}
