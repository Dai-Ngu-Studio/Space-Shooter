using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Sprite[] lives;
    public Image livesImageDisplay;
    public Text scoreText;
    public int curScore;
    public GameObject titleScreen;

    public void UpdateLives(int currentLive)
    {
        livesImageDisplay.sprite = lives[currentLive];
    }

    public void UpdateScore()
    {
        curScore += 10;

        scoreText.text = "Score: " + curScore;
    }

    public void ShowTitleScreen()
    {
        titleScreen.SetActive(true);
    }

    public void HideTitleScreen()
    {
        titleScreen.SetActive(false);
        scoreText.text = "Score: ";
    }
}
