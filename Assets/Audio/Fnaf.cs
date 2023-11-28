using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fnaf : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlayOneShot(AudioManager.instance.FNAF, this.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
