using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject overlay;
    public bool overlayon;
    void Start()
    {
        overlay.SetActive(false);
        overlayon = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (overlayon == true && Input.GetKeyDown(KeyCode.Backspace))
        {
            overlay.SetActive(false);
            overlayon = false;
        }
        else if (overlayon == false && Input.GetKeyDown(KeyCode.Backspace))
        {
            overlay.SetActive(true);
            overlayon = true;
            Debug.Log("Activate overlay");
        }
        

    }
    public void Resetlevel()
    {
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
