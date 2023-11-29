using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMelee : MonoBehaviour
{
    Inputs inputs;
    InputAction direction;
    [SerializeField]float attackRange;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] int coolDown, damage;
    private Camera mainCamera;
    private bool canAttack = true;
    #region Input ini
    private void Awake()
    {
        inputs = new Inputs();
    }
    private void OnEnable()
    {
        inputs.Player.Enable();
        inputs.Player.Melee.started += Melee;
        direction = inputs.Player.GunRotation;
    }
    private void OnDisable()
    {
        inputs.Player.Disable();
        inputs.Player.Melee.started -= Melee;
    }
    #endregion
    private void Start()
    {
        mainCamera = Camera.main;
    }
    void Melee(InputAction.CallbackContext obj)
    {
        Aim();
        if (canAttack)
        {
            Ray ray = new Ray(transform.position,Aim() );
            Debug.DrawRay(transform.position, Aim());
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit,attackRange))
            {
                Debug.Log("Attacking");
                canAttack = false;
                StartCoroutine(Attack(hit.collider.gameObject));
            }
        }
    }
    #region aiming
    private Vector3 Aim()
    {
        var (success, position) = GetMousePosition();
        if (success)
        {
            // Calculate the direction
            var direction = position - transform.position;
            // Ignore the height difference.
            direction.y = 0;
            return direction;
        }
        return transform.position;
    }

    private (bool success, Vector3 position) GetMousePosition()
    {
        var ray = mainCamera.ScreenPointToRay(direction.ReadValue<Vector2>());

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
    IEnumerator Attack(GameObject target)
    {
        Debug.Log("atacking faze 2");
        target.gameObject.SendMessage("Hit", damage, SendMessageOptions.DontRequireReceiver);
        yield return new WaitForSeconds(coolDown);
        Debug.Log($@"Player cooldown stoped at {Time.time}");
        canAttack = true;
    }
}
