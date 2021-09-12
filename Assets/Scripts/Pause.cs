using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public Text roundText;
    public GameObject ui;

    void OnEnable() {
        roundText.text = PlayerStatus.rounds.ToString();
    }

    public void Retry() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void Menu() {
        Time.timeScale = 1f;
        Debug.Log("Go to menu");
        SceneManager.LoadScene("menu");
    }

    public void GamePause() {
        Debug.Log("Game paused");
        ui.SetActive(!ui.activeSelf);
        if(ui.activeSelf) {
            Time.timeScale = 0f;
        }
        else {
            Time.timeScale = 1f;
        }
    }

    public void Continue() {
        Debug.Log("Continue");
        Time.timeScale = 1f;
        ui.SetActive(false);
    }
}
