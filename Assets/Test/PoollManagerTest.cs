using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManagerTest : MonoBehaviour
{
    public GameObject[] prefabs; // 프리팹들을 보관할 변수
    List<GameObject>[] pools; // 풀 담당하는 리스트
    public static PoolManagerTest pool;

    private void Awake()
    {

        pools = new List<GameObject>[prefabs.Length];

        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
        }
    }

    public GameObject Get(int index)
    {
        GameObject select = null; // 선택한 풀의 놀고있는(비활성화 된) 게임 오브젝트에 접근

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
