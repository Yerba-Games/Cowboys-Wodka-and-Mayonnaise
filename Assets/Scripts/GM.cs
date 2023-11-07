using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    [SerializeField] GameObject bossDoor;
    #region Singleton
    private static GM _instance;
    public static GM Instance => _instance;
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
    }
    #endregion
    public static void ActivateBossFight()
    {
        Instance.BossFight();
    }
    void BossFight()
    {
        bossDoor.SetActive(true);
    }
}
