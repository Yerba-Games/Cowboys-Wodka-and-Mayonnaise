using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetTransform : MonoBehaviour
{
    [SerializeField] Transform player;
    public static Transform playerTransform { get; private set; }
    #region Singleton
    private static PlayerGetTransform _instance;
    public static PlayerGetTransform Instance => _instance;
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
        playerTransform = player;
    }
    #endregion
}
