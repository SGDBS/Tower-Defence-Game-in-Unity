using UnityEngine;
using UnityEngine.UI;

public class LifeUI : MonoBehaviour
{
    public Text liveText;

    void Update()
    {
        liveText.text = PlayerStatus.life.ToString() + "Lives";
    }
}
