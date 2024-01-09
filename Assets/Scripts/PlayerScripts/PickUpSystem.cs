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
    [SerializeField] int healthAddAmmount,pickUps,drunkTime,sobberingTime,drunkAddDelay=50;
    [SerializeField] float addDrunknesValue,maxShake=1.4f,addShake=0.03f; //Set by dev, defines how much to add
    [SerializeField]private PlayerHealth playerHealth;
    [SerializeField] Volume drunknesVolume;
    [SerializeField] CameraDrunSwing camera;
    int currentHealth,maxHealth;
    float addDrunknes, shake=0;// private addDrunknes for definig the clamp
    Coroutine addDrunknesCorutine,decreseDrunknesCorutine;
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
                if (decreseDrunknesCorutine != null) { StopCoroutine(decreseDrunknesCorutine);decreseDrunknesCorutine = null; }
                pickUps--;
                pickUpText.text = pickUps.ToString();
                playerHealth.AddHealth(healthAddAmmount);
                addDrunknes += addDrunknesValue;
                shake += maxShake;
                if(addDrunknesCorutine!=null) { StopCoroutine(addDrunknesCorutine); addDrunknesCorutine = StartCoroutine(AddDrunknes());return; }
                addDrunknesCorutine = StartCoroutine(AddDrunknes());
                //drunknesVolume.weight += addDrunknes;
                //if (drunkResset != null)
                //{
                //    StopCoroutine(drunkResset);
                //    drunkResset = StartCoroutine(Drunkness());
                //    return;
                //}
                //drunkResset = StartCoroutine(Drunkness());
            }
        }
    }
    IEnumerator AddDrunknes()
    {
        camera.shake = true;
        int iterations = 0;
        while(drunknesVolume.weight<addDrunknes)
        {
            iterations++;
            Debug.Log($@"iteration:{iterations}");
            drunknesVolume.weight =Mathf.Clamp(drunknesVolume.weight+ (addDrunknes/ drunkAddDelay),0,addDrunknes);
            camera.intensity = Mathf.Clamp(camera.intensity + addShake, 0, shake);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(drunkTime);
        addDrunknesCorutine = null;
        decreseDrunknesCorutine = StartCoroutine(DecreseDrunknes());
    }
    IEnumerator DecreseDrunknes()
    {
        int iterations = 0;
        while (drunknesVolume.weight > 0)
        {
            iterations++;
            Debug.Log($@"iteration:{iterations}");
            drunknesVolume.weight = Mathf.Clamp(drunknesVolume.weight - (addDrunknes / drunkAddDelay), 0, addDrunknes);
            camera.intensity = Mathf.Clamp(camera.intensity-addShake,0,shake);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(sobberingTime);
        shake = 0;
        camera.shake = false;
        decreseDrunknesCorutine = null;
    }
    //IEnumerator Drunkness()
    //{
    //    yield return new WaitForSeconds(drunkTime);
    //    drunknesVolume.weight = 0;
    //    drunkResset = null;
    //}
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
