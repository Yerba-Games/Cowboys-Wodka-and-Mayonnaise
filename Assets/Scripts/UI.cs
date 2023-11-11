using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
   public static UI ui;
    int ammo, health;
    [SerializeField] GameObject[] bullets;
    [SerializeField] TMP_Text ammoText;

    private void Awake()
    {
        ui = this; 
        ammo=bullets.Length;
    }
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
}
