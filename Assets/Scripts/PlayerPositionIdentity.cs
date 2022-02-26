using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionIdentity : MonoBehaviour
{
    public Transform playerPos;

    void Update()
    {
        gameObject.transform.position = playerPos.position;
    }
}
