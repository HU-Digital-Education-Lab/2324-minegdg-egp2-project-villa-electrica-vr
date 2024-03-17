using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CircuitController : MonoBehaviour
{
private AudioSource source;
    public AudioClip errorSound;
    public AudioClip correctSound;
    // public int cableID;

    [SerializeField] private Transform[] _NTransforms;
    [SerializeField] private Transform[] _LTransforms;
    [SerializeField] private Transform[] _SLTransforms;

    public int _NIndex = 0;
    public int _LIndex = 0;
    public int _SLIndex = 0;

    public int _NLength = 0;
    public int _LLength = 0;
    public int _SLLength = 0;

    public GameObject Cable;
    public int _cableIndex = 0;

    private GameObject LevelManager;

    // Start is called before the first frame update
    void Start()
    {
        // _lineRenderer = GetComponent<LineRenderer>();
        source = GetComponent<AudioSource>();
        LevelManager = GameObject.FindGameObjectWithTag("Level Manager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_cableIndex == 0)
        {
            if (_NTransforms[0] == other.transform && _NTransforms.Length != _NIndex)
            {
                _cableIndex = 1;
                _NIndex = 1;
                _NLength = _NTransforms.Length;
                source.PlayOneShot(correctSound);
            }
            else if (_LTransforms[0] == other.transform  && _LTransforms.Length != _LIndex)
            {
                _cableIndex = 2;
                _LIndex = 1;
                _LLength = _LTransforms.Length;
                source.PlayOneShot(correctSound);
            }
            else if (_SLTransforms[0] == other.transform && _SLTransforms.Length != _SLIndex)
            {
                _cableIndex = 3;
                _SLIndex = 1;
                _SLLength = _SLTransforms.Length;
                source.PlayOneShot(correctSound);
            }
            else
            {
                Error();
            }
        }
        else if (_cableIndex == 1)
        {
            if (_NTransforms[_NIndex] == other.transform)
            {
                _NIndex += 1;
                source.PlayOneShot(correctSound);

                if (_NIndex == _NTransforms.Length)
                {
                    _cableIndex = 0;
                }
            }
            else
            {
                Error();
            }
        }
        else if (_cableIndex == 2)
        {
            if (_LTransforms[_LIndex] == other.transform)
            {
                _LIndex += 1;
                source.PlayOneShot(correctSound);

                if (_LIndex == _LTransforms.Length)
                {
                    _cableIndex = 0;
                }
            }
            else
            {
                Error();
            }
        }
        else if (_cableIndex == 3)
        {
            if (_SLTransforms[_SLIndex] == other.transform)
            {
                _SLIndex += 1;
                source.PlayOneShot(correctSound);

                if (_SLIndex == _SLTransforms.Length)
                {
                    _cableIndex = 0;
                }
            }
            else 
            {
                Error();
            }
        }

        if (_SLIndex == _SLTransforms.Length && _LIndex == _LTransforms.Length && _NIndex == _NTransforms.Length )
        {
            LevelManager.GetComponent<Level3Manager>().SetGameOver();
        }
    }

    private void Error()
    {
        source.PlayOneShot(errorSound);
        LevelManager.GetComponent<Level3Manager>().AddError();
    }
}
