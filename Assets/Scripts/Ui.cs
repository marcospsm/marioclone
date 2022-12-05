using UnityEngine.UI;
using UnityEngine;

public class Ui : MonoBehaviour
{
    public Text livesText;
    public Text coinsText;

    private void Update()
    {
        livesText.text = GameManager.Instance.lives.ToString();
        coinsText.text = GameManager.Instance.coins.ToString();
    }
}
