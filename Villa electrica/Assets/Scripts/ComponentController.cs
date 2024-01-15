using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.XR.Interaction.Tookit;
// using UnityEngine.XR.XRGrabInteractable;
using UnityEngine.XR.Interaction.Toolkit;

public class ComponentController : MonoBehaviour
{
    // Object containing zone component is supposed to touch
    public GameObject TouchZone;
    // Object containing the object that replaces the zone with a component
    public GameObject Replacement;
    public bool isPart1;

    private AudioSource source;
    public AudioClip errorSound;
    public AudioClip correctSound;

    public bool isCable;
    public bool correctPlace = false;
    private GameObject part1_clone;
    private XRGrabInteractable xri;
    Rigidbody rb;
    // XRGrabInteractable xri;




    // Start is called before the first frame update
    void Start()
    {
        // get the audio source.
        source = GetComponent<AudioSource>();
        rb =  gameObject.GetComponent<Rigidbody>();
        // xri = gameObject.GetComponent<XRGrabInteractable>();
        xri = GetComponent<XRGrabInteractable>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // check if object is in the right zone.
        if (TouchZone == other.gameObject)
        {
            if (isCable)
            {
                    rb.useGravity = false;
                    source.PlayOneShot(correctSound);
                    rb.constraints =    RigidbodyConstraints.FreezePositionX | 
                                        RigidbodyConstraints.FreezePositionY | 
                                        RigidbodyConstraints.FreezePositionZ;
                   //Destroy(xri);
                    xri.gameObject.SetActive(false);
            }
            else 
            {
                if (isPart1) 
                {
                    float objectTop = other.gameObject.transform.position.y - other.gameObject.GetComponent<Renderer>().bounds.size.y/2;
                    Vector3 position = new Vector3(other.gameObject.transform.position.x, objectTop , other.gameObject.transform.position.z);
                    part1_clone = Instantiate(Replacement, position, Quaternion.Euler(new Vector3(0, 180, 0)));
                }
                else
                {
                    Vector3 position = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, other.gameObject.transform.position.z);
                    part1_clone = Instantiate(Replacement, position, Quaternion.Euler(new Vector3(0, -90, 0)));
                }
            
                // play the right sound.
                source.PlayOneShot(correctSound);

                correctPlace = true;

                // destroy both the touch zone and the component.
                this.gameObject.SetActive(false);
                Destroy(other.gameObject, 0.2f);
            }

            
        } else {
            // play error sound when in the wrong zone.
            source.PlayOneShot(errorSound);
        }
    }

    public GameObject GetPart1Clone()
    {
        return part1_clone;
    }
}
