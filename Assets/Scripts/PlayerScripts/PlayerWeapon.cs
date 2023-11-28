using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using NaughtyAttributes;
using FMODUnity;
using UnityEngine.Animations;

//Jeba�em si� z tym 4 godziny ale dzia�a wiec lepeij tu ju� nic nie zmienia�

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private LineRenderer aimGuide;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] bool aimToY = false;
    [SerializeField] GameObject bullet,gunEnd;
    [SerializeField] ParticleSystem particle;
    [SerializeField] int magazine = 6,emitParticles=10;
    [SerializeField]float relodeTime=1,relodSpeedUp=0.25f;
    [SerializeField] Animator animator;
    [ShowNonSerializedField]private int currentMagazine;
    Coroutine RelodeCorutine;
    private Camera mainCamera;
    float currentTime=0;
    Inputs inputs; //popi�cie do klasy z inputem
    private InputAction mousePositon;
    #region Input ini
    private void Awake()
    {
        inputs = new Inputs();
        relodSpeedUp *= relodeTime;
    }
    private void OnEnable()
    {
        inputs.Player.Enable();
        mousePositon = inputs.Player.GunRotation;
        inputs.Player.Fire.performed+= CheckShoot;
        inputs.Player.Relode.performed += PlayerRelode;

    }
    private void OnDisable()
    {
        inputs.Player.Disable();
        inputs.Player.Fire.performed -= CheckShoot;
        inputs.Player.Relode.performed -= PlayerRelode;
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
    void CheckShoot(InputAction.CallbackContext obj)
    {
        if (RelodeCorutine!=null && currentMagazine > 0)
        {
            CorutineStop(ref RelodeCorutine);
        }
        Shoot();
    }
    void Shoot()
    {
        if(currentMagazine <= 0)
        {
            return;
        }
        animator.SetTrigger("shoot");
        currentMagazine--;
        UI.AmmoChange(-1);
        Debug.Log("piu");
        Instantiate(bullet, gunEnd.transform.position, gunEnd.transform.rotation);
        particle.Emit(10);
        AudioManager.instance.PlayOneShot(AudioManager.instance.PlayerShotSound, this.transform.position);
        //tempBullet.GetComponent<Rigidbody>().AddForce(transform.forward*bulletSpeed, ForceMode.Impulse);
        Relode();
    }
    private void Relode()
    {
        if (currentMagazine<= 0)
        {
            //CorutineStop(ref RelodeCorutine);
            CorutinStart(ref RelodeCorutine);
        }
    }
    bool CorutinStart(ref Coroutine coroutine/*,IEnumerator enumerato*/)
    {
        if (coroutine == null) 
        {
            coroutine = StartCoroutine(Reloding());
            return true; 
        }

        return false;
    }
    bool CorutineStop(ref Coroutine coroutine)
    {
        if (coroutine != null)
        {
            currentTime = 0;
            StopCoroutine(coroutine);
            coroutine = null;
            return true;
        }
        return false;
    }
    private void PlayerRelode(InputAction.CallbackContext obj)
    {
        if (currentMagazine < magazine)
        {
            currentTime += relodSpeedUp;
            animator.SetFloat("RelodeSpeed", animator.GetFloat("RelodeSpeed")+relodSpeedUp);
            //CorutineStop(ref RelodeCorutine);
            CorutinStart(ref RelodeCorutine);
        }
    }
    IEnumerator Reloding()
    {
        //dzwięk i animacja startu przeładowania
        for (int i = currentMagazine; i < magazine; i++)
        {
            animator.SetTrigger("Relode");
            while (currentTime <= relodeTime)
            {
                currentTime += Time.deltaTime;
                yield return null;
            }
            currentTime = 0;
            currentMagazine++;
            Debug.Log(currentMagazine);
            UI.AmmoChange(1);
            //tu dzwięk przeładowania pojedyńczeko bulleta
            //animacja pojedyńczego bulleta
            
        }
        RelodeCorutine = null;
        animator.SetFloat("RelodeSpeed", 1);
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
            //animator.SetIKRotation(AvatarIKGoal.RightHand,);
            aimGuide.SetPosition(0,transform.position);
            aimGuide.SetPosition(1, GetMousePosition().position);
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