using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimLayerFollow : MonoBehaviour
{
    [SerializeField] GameObject playerCharacter;
    private Transform playerPositon;
    // Start is called before the first frame update
    void Start()
    {
        playerPositon=playerCharacter.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerPositon.position;
    }
}
