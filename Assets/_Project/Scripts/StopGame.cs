using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StopGame : MonoBehaviour
{


    private void Update()
    {
        // sahneyi çaðýrýyoruz
        // we call the scene

        if (Input.GetKeyDown(KeyCode.R))
        {

            StartCoroutine(LoadYourAsyncScene());

            Time.timeScale = 1;
            
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        Pause();
        Debug.Log("Yeniden Baþlatmak için R tuþuna basýnýz \n Press R to Restart");
        
    }

    // burada oyunu durduruyoruz
    //  here we stop the game

    void Pause()
    {
        Time.timeScale = 0;
    }


    // yükleyeceðimiz sahneyi seçiyoruz
    // we choose the scene to load

    IEnumerator LoadYourAsyncScene()
    {

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainScene");

        while (!asyncLoad.isDone)
        {
            yield return null;
        }


    }



}
