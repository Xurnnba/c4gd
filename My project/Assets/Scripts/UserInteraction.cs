using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserInteraction : MonoBehaviour
{
    
    public void PlayGame()
    {
      SceneManager.LoadScene("ColeHuang");
        Time.timeScale = 1;
    }
}
