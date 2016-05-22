using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuButtonController : MonoBehaviour {

    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }

	public void StartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void InstButton()
    {
        SceneManager.LoadScene(2);
    }

    public void NextInst()
    {
        SceneManager.LoadScene(3);
    }
    public void QuitButton()
    {
        Application.Quit();
    }
}
