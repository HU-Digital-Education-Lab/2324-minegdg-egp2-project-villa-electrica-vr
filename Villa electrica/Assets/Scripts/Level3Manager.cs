using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3Manager : MonoBehaviour
{
    public GameObject level3;
    public GameObject endScreen;
    public string MainSceneName;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI HighScoreText;
    private int error_count = 0;
    public static int highscore;
    public bool levelOver = false;

    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("HSLevel3", highscore);
    }

    // Update is called once per frame
    void Update()
    {
        if (levelOver)
        {
            ShowEndscreen();
        }
    }

    void ShowEndscreen()
    {
        int score;
        if (error_count < 30)
        {
            score = 300 - (10 * error_count);
        }
        else
        {
            score = 0;
        }
        ScoreText.text = "" + score;

        if (score > highscore)
        {
            PlayerPrefs.SetInt("HSLevel3", score);
            HighScoreText.text = "" + score;
        }
        else
        {
            HighScoreText.text = "" + highscore;
        }

        endScreen.gameObject.SetActive(true);
        level3.gameObject.SetActive(false);
    }

    public void GoToMainScreen()
    {
        SceneManager.LoadScene(MainSceneName);
    }

    public void AddError()
    {
        error_count++;
    }

    public void SetGameOver()
    {
        levelOver = true;
    }
}
