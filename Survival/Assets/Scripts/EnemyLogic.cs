using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{

    public int  health = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Dead();
        }
    }

    public void ApplyDamage(int theDamage)
    {
        health -= theDamage;
    }
    public void Dead()
    {
        Destroy(gameObject);
    }
}
