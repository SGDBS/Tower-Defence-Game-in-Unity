using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text roundText;

    private void OnEnable() {
        roundText.text = PlayerStatus.rounds.ToString();
        Time.timeScale = 0f;
    }

    public void Retry() {
        Time.timeScale = 0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu() {
        Debug.Log("Go to menu");
    }
}
