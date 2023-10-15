using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCursor : MonoBehaviour
{
    Transform cam;
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
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = cam.rotation;
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mousePositon.ReadValue<Vector2>().x, Input.mousePosition.y,
                            -cam.position.z));
    }
}
