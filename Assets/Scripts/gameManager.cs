using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static bool GameIsOver = false;
    public GameObject gameOverUI;

    void Start() {
        GameIsOver = false; 
    }

    void Update()
    {
        if(GameIsOver) {
            return;
        }

        if(Input.GetKeyDown("e")) {
            EndGame();
            return;
        }

        if(PlayerStatus.life <= 0) {
            EndGame();
            return;
        }
    }

    void EndGame() {
        Debug.Log("àâ àâ ßË£¡");
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }
}
