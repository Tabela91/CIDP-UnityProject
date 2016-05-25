using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuButtonController : MonoBehaviour {

    //each of these functions will be called through OnClick events whenever a specific button is clicked
    //the game will then load the appropriate Scene.  

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
