using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioZone : MonoBehaviour
{
    private string theCollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        theCollider = other.tag;
        if (theCollider == "Player")
        {
            GetComponent<AudioSource>().Play();
            GetComponent<AudioSource>().loop = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        theCollider = other.tag;
        if (theCollider == "Player")
        {
            GetComponent<AudioSource>().Play();
            GetComponent<AudioSource>().loop = true;
        }
    }
}
