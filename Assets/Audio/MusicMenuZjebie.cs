using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicMenuZjebie : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlayOneShot(AudioManager.instance.MenuMusic, this.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
