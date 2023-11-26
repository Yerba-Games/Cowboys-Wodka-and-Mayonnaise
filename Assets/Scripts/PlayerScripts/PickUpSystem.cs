using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class PickUpSystem : MonoBehaviour
{
    public static PickUpSystem pUS;
    Inputs inputs;
    [SerializeField] TMP_Text PickUpText;
    [SerializeField] int HealthAddAmmount,PickUps;
    [SerializeField]private PlayerHealth playerHealth;
    // Start is called before the first frame update
    private void Awake()
    {
        pUS = this;
        inputs = new Inputs();
    }
    private void OnEnable()
    {
        inputs.Player.Enable();
        inputs.Player.PickUp.performed += UsePickUp;
    }
    private void OnDisable()
    {
        inputs.Player.Disable();
        inputs.Player.PickUp.performed -= UsePickUp;
    }
    void Start()
    {
        PickUpText.text = PickUps.ToString();
    }

    // Update is called once per frame
    void UsePickUp(InputAction.CallbackContext obj)
    {
        if (PickUps != 0)
        {
            PickUps--;
            PickUpText.text = PickUps.ToString();
            playerHealth.AddHealth(HealthAddAmmount);
        }
    }
    void PickUpAmmount()
    {
        PickUps++;
        PickUpText.text = PickUps.ToString();
    }
    public static void AddPickup()
    {
        pUS.PickUpAmmount();
    }
}
