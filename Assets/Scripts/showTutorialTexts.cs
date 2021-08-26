// Egemen Engin 
// https://github.com/egemenengin

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class showTutorialTexts : MonoBehaviour
{
    public GameObject[] tutorialTexts;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void triggerHandler( string triggeredChild,bool enter)
    {
        int counter = 0;
        
        foreach (Transform child in GetComponentsInChildren<Transform>())
        {
            if (child.name == triggeredChild)
            {
               
                
                tutorialTexts[counter-1].gameObject.SetActive(enter);
                
                counter = 0;
                
                break;
            }
            else
            {
              
                counter++;
            }
        }
    }
}
