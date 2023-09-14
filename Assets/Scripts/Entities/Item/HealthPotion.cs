using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Item
{
    public override void DestroyAfterTime()
    {
        Debug.Log("Health Potion");
        Invoke("DestroyObject", 4.0f);
    }
    public override void RunItem()
    {
        GameObject playerObject = GameObject.Find("Player");
        PlayerController playerController = playerObject.GetComponent<PlayerController>();
        playerController.RecoveryHp(0.3f);

        DestroyObject();
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (!collider.tag.Equals("Player"))
            return;
        RunItem();
    }
}