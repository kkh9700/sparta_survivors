using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPCoin : Item
{
    public override void DestroyAfterTime()
    {
        Invoke("DestroyObject", 4.0f);
    }
    public override void RunItem()
    {
        GameObject playerObject = GameObject.Find("Player");
        GameManager gameManager = playerObject.GetComponent<GameManager>();
        gameManager.
        DestroyObject();
    }
    public void DestroyObject()
    {
        Destroy(gameObject);
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            RunItem();
        }
    }
}
