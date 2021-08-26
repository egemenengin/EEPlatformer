// Egemen Engin 
// https://github.com/egemenengin

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;
public class LevelLoader : MonoBehaviour
{
    public void LoadNextLevel()
    {
        int curSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(curSceneIndex+1);
        
    }
    public void LoadLevelSelection()
    {
        Destroy(FindObjectOfType<GameSession>());
        SceneManager.LoadScene("LevelSelectionScene");
        
    }
    public void LoadOptions()
    {
        SceneManager.LoadScene("OptionsScene");
    }
    public void LoadLevel(int level)
    {
        int curSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(curSceneIndex+level);
    }
    public void quit()
    {
        Application.Quit();
    }
    public void LoadMainMenuScene()
    {
        Destroy(FindObjectOfType<GameSession>().gameObject);
        SceneManager.LoadScene("MainMenuScene");
       

    }
    public void LoadAgain()
    {
        Destroy(FindObjectOfType<GameSession>());
        int curSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(curSceneIndex);

    }
    public void openSliderBar(string sliderName)
    {
        GameObject optionObject = FindObjectOfType<Canvas>().transform.Find(sliderName).transform.Find(sliderName + "Slider").gameObject;
        optionObject.SetActive(!optionObject.activeInHierarchy);
        FindObjectOfType<optionsController>().setValues();
    }
    
}
