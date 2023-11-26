using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class PickUpSystem : MonoBehaviour
{
    public static PickUpSystem pUS;
    Inputs inputs;
    [SerializeField] TMP_Text pickUpText;
    [SerializeField] int healthAddAmmount,pickUps;
    [SerializeField]private PlayerHealth playerHealth;
    int currentHealth,maxHealth;
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
        pickUpText.text = pickUps.ToString();

    }

    // Update is called once per frame
    void UsePickUp(InputAction.CallbackContext obj)
    {
        if (currentHealth + healthAddAmmount! <= maxHealth)
        {
            if (pickUps != 0)
            {
                pickUps--;
                pickUpText.text = pickUps.ToString();
                playerHealth.AddHealth(healthAddAmmount);
            }
        }
    }
    void PickUpAmmount()
    {
        pickUps++;
        pickUpText.text = pickUps.ToString();
    }
    public static void AddPickup()
    {
        pUS.PickUpAmmount();
    }
    public static void SetMaxHP(int hp)
    {
        pUS.maxHealth = hp;
    }
    public static void SetHP(int hp)
    {
        pUS.currentHealth = hp;
    }
}
