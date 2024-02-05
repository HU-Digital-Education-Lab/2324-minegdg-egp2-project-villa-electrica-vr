using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableController : MonoBehaviour
{
    private AudioSource source;
    public AudioClip errorSound;
    public AudioClip correctSound;

    private LineRenderer lineRenderer;
    [SerializeField] private Transform[] cableTransforms;
    private int cableIndex = 0;
    public GameObject Cable;

    public bool correctPlace = false;
    private GameObject LevelManager;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        source = GetComponent<AudioSource>();
        LevelManager = GameObject.FindGameObjectWithTag("Level Manager");
    }

    void Update()
    {
        lineRenderer.positionCount = cableTransforms.Length;
        for (int i = 1; i < cableIndex; i++)
        {
            lineRenderer.SetPosition(i, cableTransforms[i].position);
        } 

        if (cableIndex == 0) 
        {
            lineRenderer.SetPosition(0, Cable.transform.position);
            lineRenderer.SetPosition(1, Cable.transform.position);
        } 
        else if (cableIndex == 1) 
        {
            lineRenderer.SetPosition(0, cableTransforms[0].position);
            lineRenderer.SetPosition(1, Cable.transform.position);
        } 
        else 
        {
            lineRenderer.SetPosition(cableIndex + 1, Cable.transform.position);
            correctPlace = true;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (cableTransforms[cableIndex] == other.transform) 
        {
            cableIndex += 1;
            source.PlayOneShot(correctSound);
        }
        else 
        {
            source.PlayOneShot(errorSound);
            LevelManager.GetComponent<Level2Manager>().AddError();
        }
    }
}
