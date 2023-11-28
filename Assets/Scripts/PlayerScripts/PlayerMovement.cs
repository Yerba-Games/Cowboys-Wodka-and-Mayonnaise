using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using NaughtyAttributes;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    Inputs inputs; //popiêcie do klasy z inputem
    [SerializeField][Foldout("Settings")] float Speed;
    [SerializeField] Animator animator;
    private Rigidbody rb;
    private InputAction move; //odbiera input z akcji move
    // Start is called before the first frame update
    private void OnEnable()
    {
        //g³ównie popina input do wartoœci w skrypcie
        inputs.Player.Enable();
        move = inputs.Player.Move;
    }
    private void OnDisable()
    {
        //zwalnianie ramu.exe
        inputs.Player.Disable();
    }

    private void Awake()
    {
        //Jebaæ rêczne popinaie
        rb = GetComponent<Rigidbody>();
        inputs = new Inputs();

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //movement
        Vector3 moveForce = new Vector3(move.ReadValue<Vector2>().x, 0, move.ReadValue<Vector2>().y);
        rb.velocity = moveForce * Speed;
        transform.rotation=Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(moveForce),Time.deltaTime*40f);
        if (moveForce != Vector3.zero)
        {
            animator.SetBool("walk", true);
            //AudioManager.instance.PlayOneShot(AudioManager.instance.PlayerSteps, this.transform.position);
            return;
        }
        animator.SetBool("walk", false);
    }
    //SEX NIE ISTNIEJE
}
