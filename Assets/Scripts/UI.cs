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
    [SerializeField] GameObject gameOverUI;

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
    public static void AmmoChange(int ammo)
    {
        ui.AmmoChangeUI(ammo);
    }
    void AmmoChangeUI(int ammoChange)
    {
        ammo+=ammoChange;
        ammoText.text=ammo.ToString();
        bool changeUI = ammoChange>0 ? true:false;
        int changeUIIndex = ammoChange > 0 ? ammo - 1 : ammo;
        bullets[changeUIIndex].SetActive(changeUI);
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
    #region GameOverUI
    public static void GameOver()
    {
        ui.ActivateGameOverUI();
    }
    private void ActivateGameOverUI()
    {
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
    }
    #endregion
}
