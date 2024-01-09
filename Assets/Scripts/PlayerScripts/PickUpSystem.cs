using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class PickUpSystem : MonoBehaviour
{
    public static PickUpSystem pUS;
    Inputs inputs;
    [SerializeField] TMP_Text pickUpText;
    [SerializeField] int healthAddAmmount,pickUps,drunkTime;
    [SerializeField] float addDrunknes;
    [SerializeField]private PlayerHealth playerHealth;
    [SerializeField] Volume drunknesVolume;
    int currentHealth,maxHealth;
    Coroutine drunkResset;
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
        if (currentHealth < maxHealth)
        {
            if (pickUps != 0)
            {
                pickUps--;
                pickUpText.text = pickUps.ToString();
                playerHealth.AddHealth(healthAddAmmount);
                drunknesVolume.weight += addDrunknes;
                if (drunkResset != null)
                {
                    StopCoroutine(drunkResset);
                    drunkResset = StartCoroutine(Drunkness());
                    return;
                }
                drunkResset = StartCoroutine(Drunkness());
            }
        }
    }
    IEnumerator Drunkness()
    {
        yield return new WaitForSeconds(drunkTime);
        drunknesVolume.weight = 0;
        drunkResset = null;
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
