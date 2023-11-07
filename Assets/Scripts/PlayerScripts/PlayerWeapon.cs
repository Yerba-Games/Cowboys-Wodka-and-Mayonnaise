using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using NaughtyAttributes;

//Jeba�em si� z tym 4 godziny ale dzia�a wiec lepeij tu ju� nic nie zmienia�

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private LayerMask groundMask;
    [SerializeField] bool aimToY = false;
    [SerializeField] GameObject bullet,gunEnd;
    [SerializeField] int magazine=6,relodeTime=2;
    [ShowNonSerializedField]private float currentMagazine;
    private bool isReloding;
    private Camera mainCamera;
    Inputs inputs; //popi�cie do klasy z inputem
    private InputAction mousePositon;
    #region Input ini
    private void Awake()
    {
        inputs = new Inputs();
    }
    private void OnEnable()
    {
        inputs.Player.Enable();
        mousePositon = inputs.Player.GunRotation;
        inputs.Player.Fire.started += Shoot;

    }
    private void OnDisable()
    {
        inputs.Player.Disable();
        inputs.Player.Fire.started -= Shoot;
    }
    #endregion
    private void Start()
    {
        mainCamera = Camera.main;
        currentMagazine = magazine;
    }

    private void Update()
    {
        Aim();
    }
    #region shooting and reloding
    void Shoot(InputAction.CallbackContext obj)
    {
        if (!isReloding) 
        {
            Debug.Log("piu");
            Instantiate(bullet, gunEnd.transform.position, gunEnd.transform.rotation);
            //tempBullet.GetComponent<Rigidbody>().AddForce(transform.forward*bulletSpeed, ForceMode.Impulse);
            Relode();
        }

        
    }
    private void Relode()
    {
        currentMagazine--;
        if (currentMagazine<= 0)
        {
            isReloding=true;
            StartCoroutine(Reloding());
        }
    }
    IEnumerator Reloding()
    {
        yield return new WaitForSeconds(relodeTime);
        currentMagazine = magazine;
        isReloding = false;
    }
    #endregion
    #region aiming
    private void Aim()
    {
        var (success, position) = GetMousePosition();
        if (success)
        {
            // Calculate the direction
            var direction = position - transform.position;
            // Ignore the height difference.
            if (!aimToY) {direction.y = 0; }
            transform.forward = direction;
        }
    }

    private (bool success, Vector3 position) GetMousePosition()
    {
        var ray = mainCamera.ScreenPointToRay(mousePositon.ReadValue<Vector2>());

        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, groundMask))
        {
            return (success: true, position: hitInfo.point);
        }
        else
        {
            return (success: false, position: Vector3.zero);
        }
    }
    #endregion
}