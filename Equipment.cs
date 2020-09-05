using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory System/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot equipSlot;

    public int AtkBonus;
    public int DefBonus;

    public override void Use()
    {
        base.Use();
        {
            base.Use();
            EquipmentManager.instance.Equip(this);

        }
    }
}

public enum EquipmentSlot
{
    Head, Body, Leg, Weapon, glove, shield
}
