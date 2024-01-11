using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagment : MonoBehaviour
{
    public string level1Name;
    public string level2Name;
    public string level3Name;

    // Start is called before the first frame update
    void Start()
    {
        
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
