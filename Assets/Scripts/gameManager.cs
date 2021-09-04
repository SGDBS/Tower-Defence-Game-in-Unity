using UnityEngine;

public class gameManager : MonoBehaviour
{
    private bool gameEnded = false;

    void Update()
    {
        if(gameEnded) {
            return;
        }
        if(PlayerStatus.life <= 0) {
            gameEnded = true;
            EndGame();
            return;
        }
    }

    void EndGame() {
        Debug.Log("àâ àâ ßË£¡");
    }
}
