using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryMenue : MonoBehaviour
{

    public void L1Retry()
    {
        SceneManager.LoadSceneAsync(1);
    }   
    public void L2Retry()
    {
        SceneManager.LoadSceneAsync(4);
    }   
    public void L3Retry()
    {
        SceneManager.LoadSceneAsync(7);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}

