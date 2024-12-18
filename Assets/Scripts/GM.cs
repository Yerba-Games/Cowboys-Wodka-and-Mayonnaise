using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    //[SerializeField] GameObject bossDoor;
    [SerializeField] GameObject[] Door;
    [SerializeField] EndGuider endGuider;
    [SerializeField] GameObject endText;
    [SerializeField] int endTextTime;
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
        foreach (GameObject go in Door)
        {
            go.transform.DORotate(new Vector3(0, 120, 0), 1);
        }
        //endGuider.Guide();
        //bossDoor.SetActive(true);
        endText.SetActive(true);
        StartCoroutine(disableAfter());
    }
    IEnumerator disableAfter()
    {
        yield return new WaitForSeconds(endTextTime);
        endText.SetActive(false);
    }
}
