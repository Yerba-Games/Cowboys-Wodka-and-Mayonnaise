using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using NaughtyAttributes;

//Jeba³em siê z tym 4 godziny ale dzia³a wiec lepeij tu ju¿ nic nie zmieniaæ

public class PlayerWeapon : MonoBehaviour
{
    #region Singleton
    private static PlayerWeapon _instance;
    public static PlayerWeapon Instance => _instance;
    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
        inputs = new Inputs();
    }
    #endregion
    [SerializeField] private LayerMask groundMask;
    [SerializeField] bool aimToY = false;
    [SerializeField] GameObject bullet,gunEnd;
    [SerializeField] float bulletSpeed;
    [SerializeField] int magazine=6,relodeTime=2;
    [ShowNonSerializedField]private float currentMagazine;
    private bool isReloding;
    public static float bulletSingletonSpeed;

    private Camera mainCamera;
    Inputs inputs; //popiêcie do klasy z inputem
    private InputAction mousePositon;
    #region Input ini
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
        bulletSingletonSpeed = bulletSpeed;
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
            GameObject tempBullet = Instantiate(bullet, gunEnd.transform.position, gunEnd.transform.rotation);
            tempBullet.GetComponent<Rigidbody>().AddForce(transform.forward*bulletSpeed, ForceMode.Impulse);
            Relode();
        }

        
    }
    private void Relode()
    {
        currentMagazine--;
        if (currentMagazine< 0)
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