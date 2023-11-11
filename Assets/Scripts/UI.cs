using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
   public static UI ui;
    int ammo;
    [SerializeField] GameObject[] bullets;
    [SerializeField] TMP_Text ammoText,healthText;
    [SerializeField] Slider healthSlider;

    private void Awake()
    {
        ui = this; 
        ammo=bullets.Length;
    }
    #region AmmoUI
    /// <summary>
    /// if there is no argumenst it removes ammo from ui else if false, it adds all ammo to ui
    /// </summary>
    /// <param name="RemoveAmmo"></param>
    public static void RemoveAmmo(bool RemoveAmmo=true)
    {
        if (RemoveAmmo) { ui.AmmoRemoveBullets(); return; }
        ui.AmmoRelode();
    }
    void AmmoRemoveBullets()
    {
        ammo--;
        ammoText.text=ammo.ToString();
        bullets[ammo].SetActive(false);
    }
    void AmmoRelode()
    {
        ammo=bullets.Length;
        ammoText.text = ammo.ToString();
        for (int i = 0; i < ammo; i++) { bullets[i].SetActive(true); }

    }
    #endregion
    #region HealthUI
    void SetHP(int curentHP)
    {
        healthText.text = curentHP.ToString();
        healthSlider.value = curentHP;
    }
    public static void SetHealth(int curentHealth)
    {
        ui.SetHP(curentHealth);
    }
    public static void SetMaxHP(int hp)
    {
        ui.LocalSMHP(hp);
    }
    void LocalSMHP(int hp) 
    {
        healthSlider.maxValue = hp;
        healthSlider.value = hp;
        healthText.text = hp.ToString();
    }
    #endregion
}
