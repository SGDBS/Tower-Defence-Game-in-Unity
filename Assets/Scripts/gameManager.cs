using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static bool GameIsOver = false;
    public GameObject gameOverUI;
    public GameObject gamePauseUI;

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

        if (Input.GetKeyDown(KeyCode.Escape)) {
            gamePauseUI.GetComponent<Pause>().GamePause();
        }


        if (PlayerStatus.life <= 0) {
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
