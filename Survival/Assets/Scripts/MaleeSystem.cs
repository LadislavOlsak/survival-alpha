using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaleeSystem : MonoBehaviour
{
    public int theDamage = 50;
    public float maxDistance = 1.5f;
    public Transform theMace;
    
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
            // attack animation
            theMace.GetComponent<Animator>().SetTrigger("Attack");

            // attack function
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
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            theMace.GetComponent<Animator>().SetTrigger("Sprint");
            theMace.GetComponent<Animator>().SetBool("IsSprinting", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            theMace.GetComponent<Animator>().SetTrigger("Stop Sprint");
            theMace.GetComponent<Animator>().SetBool("IsSprinting", false);
        }
    }
}
