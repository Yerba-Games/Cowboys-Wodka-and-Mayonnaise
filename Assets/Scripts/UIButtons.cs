using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void Change(GameObject image)
    {
        image.SetActive(false);
    }
    public void Hide(GameObject button)
    {
        button.SetActive(false);
    }
}
