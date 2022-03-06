using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public HealthBar healthBarPrefab;
    HealthBar healthBar;
    public Inventory inventoryPrefab;
    Inventory inventory;

    void Start()
    {
        inventory = Instantiate(inventoryPrefab);

        hitPoints.value = startingHitPoints;
        healthBar = Instantiate(healthBarPrefab);
        healthBar.character = this;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CanBePickedUp"))
        {
            Item hitObject = collision.gameObject.GetComponent<Consumable>().item;

            if (hitObject != null)
            {
                bool shouldDissappear = false;

                switch (hitObject.itemType)
                {
                    case Item.ItemType.COIN: 
                        shouldDissappear = inventory.AddItem(hitObject);
                        break;
                    case Item.ItemType.HEALTH:
                        shouldDissappear = AdjustHitPoints(hitObject.quantity);
                        break;
                    default:
                        break;
                }
                if(shouldDissappear)
                {
                    collision.gameObject.SetActive(false);
                }
            }

        }
    }

    public bool AdjustHitPoints(int amount)
    {
        if(hitPoints.value < maxHitPoints)
        {
            hitPoints.value = hitPoints.value + amount;
            print("Adjusted hitpoints by: " + amount + ". New value: " + hitPoints.value);
            
            return true;
        }
        return false;
    }
}

