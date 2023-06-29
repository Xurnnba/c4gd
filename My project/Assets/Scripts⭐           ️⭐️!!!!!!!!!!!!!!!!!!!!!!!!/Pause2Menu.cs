using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause2Menu : MonoBehaviour
{
    public Button resume;
    public Button menu;
    public Button pause;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowButtons()
    {
        resume.gameObject.SetActive(true);
        menu.gameObject.SetActive(true);
        pause.gameObject.SetActive(false);
        Time.timeScale = 0;
    }

    public void ShowMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Resume()
    {
        Time.timeScale = 1;
        resume.gameObject.SetActive(false);
        menu.gameObject.SetActive(false);
        pause.gameObject.SetActive(true);
    }
    

}
