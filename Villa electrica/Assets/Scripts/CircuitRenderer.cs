using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitRenderer : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    // public CircuitController circuitValues;
    // GameObject Script = GameObject.Find("Cable");
    
    public int SectionID;
    private int length = 0;
    private int index = 0;

    [SerializeField] private Transform[] _cableTransforms;
    public GameObject Cable;
    // CircuitController CircuitValues = Cable.GetComponent<CircuitController>()._NIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        
        _lineRenderer = GetComponent<LineRenderer>();
        
        
        // if (SectionID == 1)
        // {
            
            
        // }
        // else if (SectionID == 2)
        // {
            
            
        // }
        // else if (SectionID == 3)
        // {
            
            
        // }
    }

    // Update is called once per frame
    void Update()
    {
        if (SectionID == 1)
        {
            length = Cable.GetComponent<CircuitController>()._NLength;
            index = Cable.GetComponent<CircuitController>()._NIndex;
        }
        else if (SectionID == 2)
        {
            length = Cable.GetComponent<CircuitController>()._LLength;
            index = Cable.GetComponent<CircuitController>()._LIndex;
        }
        else if (SectionID == 3)
        {
            length = Cable.GetComponent<CircuitController>()._SLLength;
            index = Cable.GetComponent<CircuitController>()._SLIndex;
        }

        _lineRenderer.positionCount = length;
        for (int i = 0; i < index; i++)
        {
            _lineRenderer.SetPosition(i, _cableTransforms[i].position);

        } 
    }
}
