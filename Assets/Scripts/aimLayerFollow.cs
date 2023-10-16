using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimLayerFollow : MonoBehaviour
{
    [SerializeField] Transform playerCharacterPositon;
    void Update()
    {
        transform.position = playerCharacterPositon.position;
    }
}
