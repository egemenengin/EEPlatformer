// Egemen Engin 
// https://github.com/egemenengin

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showTutorialTextsTrigger : MonoBehaviour
{
    bool entered = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!entered)
        {
            transform.parent.GetComponent<showTutorialTexts>().triggerHandler(transform.name, true);
            entered = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.parent.GetComponent<showTutorialTexts>().triggerHandler(transform.name, false);

        entered = false;
    }

}
