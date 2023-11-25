using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PickUpScript : MonoBehaviour
{
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = PlayerGetTransform.playerTransform;
        //transform.DORotate(new Vector3(0, 360, 0), 1, RotateMode.Fast).SetLoops(-1,LoopType.Restart).SetEase(Ease.Linear) ;
        //transform.DOMove(new Vector3(0, 2, 0), 1).SetLoops(-1,LoopType.Restart);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= 0.1f)
        {
            PickUpSystem.AddPickup();
            Destroy(gameObject);
        }
    }
}
