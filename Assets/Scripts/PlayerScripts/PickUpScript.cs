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
        transform.DORotate(new Vector3(0, 180, 0), 1, RotateMode.Fast).SetLoops(-1,LoopType.Restart).SetEase(Ease.Linear) ;
        transform.DOMoveY(transform.position.y+0.5f, 1).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.Linear);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(Vector3.Distance(transform.position, player.transform.position));
        if (Vector3.Distance(transform.position, player.transform.position) <= 1.5f)
        {
            Debug.Log("picked");
            PickUpSystem.AddPickup();
            gameObject.SetActive(false);
        }
    }
}
