using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu]
public class ItemDropTable : ScriptableObject
{

    [System.Serializable]
    public class Items
    {
        public GameObject item;
        public int weight;
    }

    public List<Items> items = new List<Items>();

    protected GameObject PickItem()
    {
        int sum = 0;

        foreach (var item in items)
        {
            sum += item.weight;
        }

        var rnd = Random.Range(0, sum);

        for (int i = 0; i < items.Count; i++)
        {
            var item = items[i];
            if (item.weight > rnd) return items[i].item;
            else rnd -= item.weight;
        }

        return null;
    }

    public void ItemDrop(Vector3 pos, int exp)
    {
        var item = PickItem();
        if (item == null) return;

        ExpCoin coin = item.GetComponent<ExpCoin>();

        if (coin != null)
            coin.SetExp(exp);

        Instantiate(item, pos, Quaternion.identity);
    }
}
