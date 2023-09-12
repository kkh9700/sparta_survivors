using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTest : MonoBehaviour
{
    RectTransform rect;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    private void FixedUpdate()
    {
        rect.position = Camera.main.WorldToScreenPoint(GameManagerTest.instanceTest.player.transform.position);
        
    }
}
