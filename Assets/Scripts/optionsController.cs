// Egemen Engin 
// https://github.com/egemenengin

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class optionsController : MonoBehaviour
{
    Slider volumeSlider;
    Slider difficultySlider;
    float defaultVolume = 0.2f;
    float defaultDifficulty = 1f;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider = FindObjectOfType<Canvas>().transform.Find("Volume").Find("VolumeSlider").GetComponent<Slider>();
        difficultySlider = FindObjectOfType<Canvas>().transform.Find("Difficulty").Find("DifficultySlider").GetComponent<Slider>(); 
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void setDefault()
    {
        if (volumeSlider!=null)
        {
            volumeSlider.value = defaultVolume;
        }
        if (difficultySlider != null)
        {
            difficultySlider.value = defaultDifficulty;
        }
       
    }
    public void saveAndExit()
    {
        PlayerPrefsController.setVolume(volumeSlider.value);
        PlayerPrefsController.setDifficulty(difficultySlider.value);
    }
    public void setValues()
    {
        volumeSlider.value = PlayerPrefsController.getVolume();
        difficultySlider.value = PlayerPrefsController.getDifficulty();
    }
}
