using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIButtons : MonoBehaviour
{
    [SerializeField] GameObject[] images;
    int index,maxIndex;
    [SerializeField] string SceneName,endText;
    private void OnDisable()
    {
        index = 0;
    }
    private void Start()
    {
        maxIndex=images.Length-1;
    }
    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void Change(GameObject button)
    {
        if (index < maxIndex)
        {
            if(index>maxIndex-2) { ChangeText(button); }
            images[index].SetActive(false);
            index++;
            images[index].SetActive(true);
            return;
        }
        LoadScene(SceneName);
    }
    void ChangeText(GameObject button)
    {
;       button.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = endText;
    }
}
