using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaceSystem : MonoBehaviour
{
    public int theDamage = 50;
    public float maxDistance = 1.5f;
    public Transform theSystem;
    
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
            GetComponent<Animator>().SetTrigger("Attack");
        }
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            GetComponent<Animator>().SetTrigger("Sprint");
            GetComponent<Animator>().SetBool("IsSprinting", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            GetComponent<Animator>().SetTrigger("Stop Sprint");
            GetComponent<Animator>().SetBool("IsSprinting", false);
        }
    }

    public void AttackDamage()
    {
        // attack function
        RaycastHit hit;
        if (Physics.Raycast(theSystem.position, theSystem.TransformDirection(Vector3.forward), out hit))
        {
            distance = hit.distance;
            if (distance <= maxDistance)
            {
                hit.transform.SendMessage("ApplyDamage", theDamage, SendMessageOptions.DontRequireReceiver);
            }
        }
    }

}
