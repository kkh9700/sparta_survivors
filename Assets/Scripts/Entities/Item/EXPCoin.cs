using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpCoin : Item
{
    [SerializeField] private int Exp;
    public override void DestroyAfterTime()
    {
        Debug.Log("Exp Coin");
        Invoke("DestroyObject", 4.0f);
    }
    public override void RunItem()
    {
        GameManager.I.AddExp(Exp);
        DestroyObject();
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    public void SetExp(int exp)
    {
        Exp = exp;
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (!collider.tag.Equals("Player"))
            return;
        RunItem();
    }
}
