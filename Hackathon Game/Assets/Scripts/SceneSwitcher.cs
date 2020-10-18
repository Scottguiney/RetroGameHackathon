using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void GoToMainScene()
    {
        SceneManager.LoadScene("Main");
    }

    // Update is called once per frame
    public void GoToMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
    public void GoToInstruction()
    {
        SceneManager.LoadScene("HowPlay");
    }
}
