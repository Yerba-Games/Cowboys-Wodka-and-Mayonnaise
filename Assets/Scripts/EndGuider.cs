using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EndGuider : MonoBehaviour
{
    [SerializeField]Transform start, end;
    [SerializeField] float duration=5;
    public void Guide()
    {
        gameObject.SetActive(true);
        transform.position = start.position;
        transform.DOMove(end.position, duration);
    }

}
