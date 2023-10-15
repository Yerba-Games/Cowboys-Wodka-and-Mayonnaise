using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//Jeba³em siê z tym 4 godziny ale dzia³a wiec lepeij tu ju¿ nic nie zmieniaæ

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private LayerMask groundMask;
    [SerializeField] bool aimToY = false;

    private Camera mainCamera;
    Inputs inputs; //popiêcie do klasy z inputem
    private InputAction mousePositon;

    private void Awake()
    {
        inputs = new Inputs();
    }
    private void OnEnable()
    {
        inputs.Player.Enable();
        mousePositon = inputs.Player.GunRotation;
    }
    private void OnDisable()
    {
        inputs.Player.Disable();
    }
    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        Aim();
    }


    private void Aim()
    {
        var (success, position) = GetMousePosition();
        if (success)
        {
            // Calculate the direction
            var direction = position - transform.position;
            // Ignore the height difference.
            if (!aimToY) {direction.y = 0; }

            // Make the transform look in the direction.
            transform.forward = direction;
        }
    }

    private (bool success, Vector3 position) GetMousePosition()
    {
        var ray = mainCamera.ScreenPointToRay(mousePositon.ReadValue<Vector2>());

        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, groundMask))
        {
            // The Raycast hit something, return with the position.
            return (success: true, position: hitInfo.point);
        }
        else
        {
            // The Raycast did not hit anything.
            return (success: false, position: Vector3.zero);
        }
    }
}

