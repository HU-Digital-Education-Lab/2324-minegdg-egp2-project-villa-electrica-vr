using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Manager : MonoBehaviour
{
    public GameObject part1;
    public GameObject part2;
    public string MainSceneName;
    public List<GameObject> hitboxes_part1;
    public List<GameObject> hitboxes_part2;
    public bool part1_active = true;

    // Start is called before the first frame update
    void Start()
    {
        
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
                SceneManager.LoadScene(MainSceneName);
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
}
