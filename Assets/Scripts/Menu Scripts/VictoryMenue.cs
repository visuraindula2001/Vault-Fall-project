using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMenue : MonoBehaviour
{

    public void QuitGame()
    {
        Application.Quit();
    }   
    public void L1Retry()
    {
        SceneManager.LoadSceneAsync(1);
    }   
    public void L1Next()
    {
        SceneManager.LoadSceneAsync(4);
    } 

    public void L2Retry()
    {
        SceneManager.LoadSceneAsync(4);
    }
    public void L2Next()
    {
        SceneManager.LoadSceneAsync(7);
    }

    public void L3Retry()
    {
        SceneManager.LoadSceneAsync(7);
    }
   
}

