using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaleeSystem : MonoBehaviour
{
    public int theDamage = 50;
    public float maxDistance = 1.5f;
    
    float distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
                distance = hit.distance;
                if (distance <= maxDistance)
                {
                    hit.transform.SendMessage("ApplyDamage", theDamage, SendMessageOptions.DontRequireReceiver);
                }
            }
        }
        
    }
}
