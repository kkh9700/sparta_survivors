using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject[] prefabs; // �����յ��� ������ ����
    List<GameObject>[] pools; // Ǯ ����ϴ� ����Ʈ
    public static PoolManager I;

    private void Awake()
    {
        if (I == null)
        {
            I = this;
        }
        else if (I != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);


        pools = new List<GameObject>[prefabs.Length];

        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null; // ������ Ǯ�� ����ִ�(��Ȱ��ȭ ��) ���� ������Ʈ�� ����

        foreach (GameObject item in pools[index])
        {
            if (!item.activeSelf)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }
        if (!select)
        {
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }

        return select;
    }
}
