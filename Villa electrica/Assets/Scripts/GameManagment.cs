using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagment : MonoBehaviour
{
    public string level1Name;
    public string level2Name;
    public string level3Name;
    public TextMeshProUGUI HighScoreLevel1Text;
    public TextMeshProUGUI HighScoreLevel2Text;
    public TextMeshProUGUI HighScoreLevel3Text;

    // Start is called before the first frame update
    void Start()
    {
        int HighScore = PlayerPrefs.GetInt("HSLevel1");
        HighScoreLevel1Text.text = "" + HighScore;
        HighScore = PlayerPrefs.GetInt("HSLevel2");
        HighScoreLevel2Text.text = "" + HighScore;
        HighScore = PlayerPrefs.GetInt("HSLevel3");
        HighScoreLevel3Text.text = "" + HighScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartLevel1()
    {
        SceneManager.LoadScene(level1Name);
    }

    public void StartLevel2()
    {
        SceneManager.LoadScene(level2Name);
    }

    public void StartLevel3()
    {
        SceneManager.LoadScene(level3Name);
    }
}
