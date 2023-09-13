using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : Item
{
    public override void DestroyAfterTime()
    {
        Invoke("DestroyObject", 4.0f);
    }
    public override void RunItem()
    {
        GameObject playerObject = GameObject.Find("Player");
        PlayerController playerController = playerObject.GetComponent<PlayerController>();
        playerController.SetSpeed(1.5f);

        DestroyObject();
    }
    public void DestroyObject()
    {
        Destroy(gameObject);
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            RunItem();
        }
    }
}