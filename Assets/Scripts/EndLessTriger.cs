using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLessTriger : MonoBehaviour
{
    public static EndLessTriger instance;
    public static bool endless=false;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    public void IsEndless()
    {
        endless = true;
        SceneManager.LoadScene("Story");
    }
}
