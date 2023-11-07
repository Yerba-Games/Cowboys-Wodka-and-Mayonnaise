using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class AudioManager : MonoBehaviour
{

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
        Debug.Log("Kostek ty kurwo jebana<3");
    }
}
