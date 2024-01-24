using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Level2Manager : MonoBehaviour
{
    public GameObject level2;
    public GameObject endScreen;
    public string MainSceneName;
    public List<GameObject> hitboxes_level2;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI HighScoreText;
    private int error_count = 0;
    public static int highscore;

    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("HSLevel2", highscore);
    }

    // Update is called once per frame
    void Update()
    {
        bool done = true;

        foreach (GameObject component in hitboxes_level2)
        {
            CableController cableController = component.GetComponent<CableController>();
            if (!cableController.correctPlace)
            {
                done = false;
                break;
            }
        }

        if (done)
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
            PlayerPrefs.SetInt("HSLevel2", score);
            HighScoreText.text = "" + score;
        }
        else
        {
            HighScoreText.text = "" + highscore;
        }

        endScreen.gameObject.SetActive(true);
        foreach (GameObject component in hitboxes_level2)
        {
            CableController cableController = component.GetComponent<CableController>();
            //cableController.GetPart1Clone().SetActive(false);
        }
        level2.gameObject.SetActive(false);
    }

    public void GoToMainScreen()
    {
        SceneManager.LoadScene(MainSceneName);
    }

    public void AddError()
    {
        error_count++;
    }
}

