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
    [SerializeField] public EventReference EnemyVoiceOver;
    [SerializeField] public EventReference PlayerHitSound;
    [SerializeField] public EventReference PlayerDeathSound;
    [SerializeField] public EventReference LastReload;
    [SerializeField] public EventReference Reload;
    [SerializeField] public EventReference PickUpSound;
    [SerializeField] public EventReference PlayerHeal;
    [SerializeField] public EventReference PlayerLowSound;
    [SerializeField] public EventReference PlayerShotSound;
    [SerializeField] public EventReference PlayerReloadSound;
    [SerializeField] public EventReference PlayerVoiceOver;
    [SerializeField] public EventReference PlayerSteps;
    [SerializeField] public EventReference WorldAmbient;
    [SerializeField] public EventReference WorldMusic;
    [SerializeField] public EventReference WorldWoodDoor;

    public static AudioManager instance { get; private set; }

    public void Awake()
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
    
    public void PlayLoop(EventReference sound, Vector2 worldPos)
    {
        FMOD.Studio.EventInstance instance = RuntimeManager.CreateInstance(sound);
        instance.set3DAttributes(RuntimeUtils.To3DAttributes(worldPos));
        instance.start();
        instance.release(); // Release the instance immediately to avoid leaks
    }
}
