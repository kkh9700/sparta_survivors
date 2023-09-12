using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerTest : MonoBehaviour
{
    public float scanRange;
    public LayerMask targetLayer;
    public RaycastHit2D[] targets;
    public Transform nearestTarget;

    private void FixedUpdate()
    {
        targets = Physics2D.CircleCastAll(transform.position, scanRange, Vector2.zero, 0, targetLayer); // CircleCastAll은 원형으로 Ray를 쏘고 맞은 targetLayer(LayerMask)를 모두 반환
        nearestTarget = GetNearest();
        

    }

    Transform GetNearest() // 가장 가까운 target의 위치를 리턴
    {
        Transform result = null;
        float diff = 100;

        foreach(RaycastHit2D target in targets)
        {
            Vector3 myPos = transform.position;
            Vector3 targetPos = target.transform.position;
            float curDiff = Vector3.Distance(myPos, targetPos);

            if(curDiff < diff)
            {
                diff = curDiff;
                result = target.transform; 
            }
        }


        return result;
    }

}
