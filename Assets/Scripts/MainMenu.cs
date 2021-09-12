using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string levelToLoad = "gameRunning";
   
    public void Play() {
        Debug.Log("Game Start!!!");
        SceneManager.LoadScene(levelToLoad);
    }

    public void Quit() {
        Debug.Log("Quit");
        Application.Quit();
    }
}
