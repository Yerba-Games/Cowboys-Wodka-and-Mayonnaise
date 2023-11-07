using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //¯ycie proste jest jak budowa T-55, bo jestem iñ¿ynierem trzymam zaciœniêt¹ piêœæ
    [SerializeField][ProgressBar("Health", 100, EColor.Red)]int health=100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EnemyHit(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
        //I bang moge skurwysynów nokautowaæ rozpierdalam czo³gi lekko ja i moja za³oga
    }
}
