using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Level1Manager : MonoBehaviour
{
    public GameObject part1;
    public GameObject part2;
    public GameObject endScreen;
    public string MainSceneName;
    public List<GameObject> hitboxes_part1;
    public List<GameObject> hitboxes_part2;
    public bool part1_active = true;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI HighScoreText;
    private int error_count = 0;
    public static int highscore;

    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("HSLevel1", highscore);
    }

    // Update is called once per frame
    void Update()
    {
        if (part1_active) 
        {
            bool done = true;

            foreach (GameObject component in hitboxes_part1)
            {
                ComponentController componentController = component.GetComponent<ComponentController>();
                if (!componentController.correctPlace)
                {
                    done = false;
                    break;
                }
            }

            if (done)
            {
                StartPart2();
                part1_active = false;
            }
        }
        else 
        {
            bool done = true;

            foreach (GameObject component in hitboxes_part2)
            {
                ComponentController componentController = component.GetComponent<ComponentController>();
                if (!componentController.correctPlace)
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
    }

    void StartPart2()
    {
        foreach (GameObject component in hitboxes_part1)
        {
            ComponentController componentController = component.GetComponent<ComponentController>();
            componentController.GetPart1Clone().SetActive(false);
        }
        part1.gameObject.SetActive(false);
        part2.gameObject.SetActive(true);
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
            PlayerPrefs.SetInt("HSLevel1", score);
            HighScoreText.text = "" + score;
        }
        else
        {
            HighScoreText.text = "" + highscore;
        }

        endScreen.gameObject.SetActive(true);
        foreach (GameObject component in hitboxes_part2)
        {
            ComponentController componentController = component.GetComponent<ComponentController>();
            componentController.GetPart1Clone().SetActive(false);
        }
        part2.gameObject.SetActive(false);
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

