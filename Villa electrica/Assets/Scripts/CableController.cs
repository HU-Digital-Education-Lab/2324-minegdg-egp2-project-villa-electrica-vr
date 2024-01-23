using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableController : MonoBehaviour
{

    private AudioSource source;
    public AudioClip errorSound;
    public AudioClip correctSound;

    private LineRenderer _lineRenderer;

    [SerializeField] private Transform[] _cableTransforms;
    
    public GameObject Cable;

    private int _cableIndex = 1;
    // Start is called before the first frame update
    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        source = GetComponent<AudioSource>();
        // LevelManager = GameObject.FindGameObjectWithTag("Level Manager");


    }

    // Update is called once per frame
    void Update()
    {
        _lineRenderer.positionCount = _cableTransforms.Length;
        for (int i = 1; i < _cableIndex; i++)
        {
            _lineRenderer.SetPosition(i, _cableTransforms[i].position);
        } 
        if (_cableIndex == 1)
        {
            _lineRenderer.SetPosition(0, _cableTransforms[0].position);
            _lineRenderer.SetPosition(1, Cable.transform.position);
        } else {
            _lineRenderer.SetPosition(_cableIndex + 1, Cable.transform.position);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_cableTransforms[_cableIndex] == other.transform) 
        {
            _cableIndex += 1;
            source.PlayOneShot(correctSound);
        }
        else 
        {
            source.PlayOneShot(errorSound);
            // LevelManager.GetComponent<Level1Manager>().AddError();
        }
    }
}
