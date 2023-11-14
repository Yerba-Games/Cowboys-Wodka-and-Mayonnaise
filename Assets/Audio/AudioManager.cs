using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class AudioManager : MonoBehaviour
{

    [SerializeField] public EventReference EnemyHitSound;
    [SerializeField] public EventReference EnemyDeathSound;
    [SerializeField] public EventReference EnemyMeleeSound;
    [SerializeField] public EventReference EnemyShotSound;
    [SerializeField] public EventReference PlayerHitSound;
    [SerializeField] public EventReference PlayerDeathSound;
    [SerializeField] public EventReference PlayerLowSound;
    [SerializeField] public EventReference PlayerShotSound;
    [SerializeField] public EventReference PlayerReloadSound;
    [SerializeField] public EventReference WorldAmbient;
    [SerializeField] public EventReference WorldWoodDoor;

    public static AudioManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("O kurwa ni dziala, wincej niz jeden audio manager w scenie");
        }
        instance = this;
    }

    public void PlayOneShot(EventReference sound, Vector2 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
        
    }
}
