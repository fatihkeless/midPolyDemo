using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{

    public GameObject levelEndUI;
    public GameObject failUI;
    public GameObject settings;
    // bunun yerine üç yýldýz sistemi gelecek
    public Image starsImage;
    public float starsCount;
    public static int starsDelete;
    private float starsAmount;


    // Start is called before the first frame update
    void Start()
    {
        settings.SetActive(true);
        starsDelete = 0;
        starsCount = GameManager.garbage.Length;
    }

    // Update is called once per frame
    void Update()
    {
        starsAmount = (1 / starsCount) * starsDelete;
        starsImage.fillAmount = starsAmount;
        if (FollowLine.gameOver)
        {
            if (starsAmount >= 0.5f)
            {
                StartCoroutine(nextLevel());
            }
            else if( starsAmount < 0.5f)
            {
                StartCoroutine(failLevel());
            }
           
        }
    }


    public void Replay()
    {
        //  int currentSceneIndexReplay = SceneManager.GetActiveScene().buildIndex;
        //SceneManager.LoadScene(currentSceneIndexReplay + 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("is working");
        Time.timeScale = 1;
        FollowLine.gameOver = false;

    }

    public void Resume()
    {
        Time.timeScale = 1;
    }



    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void next()
    {
        Time.timeScale = 0;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        FollowLine.gameOver = false;
    }

    public void vibrationOn()
    {
        FollowLine.vibration = true;
        Debug.Log("Vibration On");
    }

    public void vibraionOff()
    {
        FollowLine.vibration = false;
        Debug.Log("Vibration Off");
    }


    IEnumerator nextLevel()
    {
        yield return new WaitForSeconds(1);
        levelEndUI.SetActive(true);
        settings.SetActive(false);
    }

    IEnumerator failLevel()
    {
        yield return new WaitForSeconds(1);
        failUI.SetActive(true);
        settings.SetActive(false);
    }

}
