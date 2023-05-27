using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISimple : MonoBehaviour
{
    private float Distance;
    public GameObject Target;
    public float LookAtDistance = 25.0f;
    public float AttackRange = 15.0f;
    public float MoveSpeed = 5.0f;
    public float Damping = 6.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Distance = Vector3.Distance(Target.transform.position, transform.position);
        //Debug.Log(Distance);
    
        if (Distance < LookAtDistance)
        {
            GetComponent<Renderer>().material.color = Color.yellow;
            LookAt();
        }
        if (Distance > LookAtDistance)
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
        if (Distance < AttackRange)
        {
            GetComponent<Renderer>().material.color = Color.red;
            Attack();
        }
    }

    private void LookAt()
    {
        var rotation = Quaternion.LookRotation(Target.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);
    }

    private void Attack()
    {
        transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
    }
}
