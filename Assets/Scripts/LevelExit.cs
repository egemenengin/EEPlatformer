// Egemen Engin 
// https://github.com/egemenengin

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelExit : MonoBehaviour
{
    public Sprite openedDoorTop;
    public Sprite openedDoorMid;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(levelFinished());
    }
    IEnumerator levelFinished()
    {
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = openedDoorTop;
        transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = openedDoorMid;
        Debug.Log(Time.timeScale);
        Time.timeScale = 0.5f;
        FindObjectOfType<Player>().GetComponent<Animator>().SetTrigger("isFinished");
        yield return new WaitForSecondsRealtime(2f);
        Time.timeScale = 1f;

        FindObjectOfType<Canvas>().transform.Find("WinPanel").gameObject.SetActive(true);

    }

}
