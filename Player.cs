using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Inventory inventory;
    public GameObject inventoryUI; //added by myself
    public int health = 30;
    public int experience = 30;
    public int gold = 500;

    public Quest quest;
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }// added by myself

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            inventory.AddItem(other.GetComponent<Item>());
            Destroy(other.gameObject);
        }
    }

    public void GoBattle()
    {
        health -= 5;
        experience += 10;
        gold += 10;

        if (quest.isActive)
        {
            quest.questGoal.EnemyDestroy();
            if (quest.questGoal.IsReached())
            {
                experience += quest.experienceReward;
                gold += quest.goldReward;
                quest.Complete();
            }
        }
    }
}
