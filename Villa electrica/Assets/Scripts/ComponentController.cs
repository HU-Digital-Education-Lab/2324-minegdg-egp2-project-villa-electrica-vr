using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentController : MonoBehaviour
{
    // Object containing zone component is supposed to touch
    public GameObject TouchZone;
    // Object containing the object that replaces the zone with a component
    public GameObject Replacement;

    private AudioSource source;
    public AudioClip errorSound;
    public AudioClip correctSound;
    // Start is called before the first frame update
    void Start()
    {
        // get the audio source.
        source = GetComponent<AudioSource>();
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
            // get size of object
            float objectSize = other.gameObject.GetComponent<Renderer>().bounds.size.y;
            // get top position of object
            float objectTop = other.gameObject.transform.position.y - objectSize/2;

            // create a new position for the replacement object.
            Vector3 position = new Vector3(other.gameObject.transform.position.x, objectTop , other.gameObject.transform.position.z);

            // instantiate the replacement.
            Instantiate(Replacement, position, Quaternion.Euler(new Vector3(0, 180, 0)));
            
            // play the right sound.
            source.PlayOneShot(correctSound);

            // destroy both the touch zone and the component.
            Destroy(gameObject, 0.2f);
            Destroy(other.gameObject, 0.2f);
            
        } else {
            // play error sound when in the wrong zone.
            source.PlayOneShot(errorSound);
        }
    }
}
