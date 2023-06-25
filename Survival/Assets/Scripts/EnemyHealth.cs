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
        
    }

    public void ApplyDamage(int theDamage)
    {
        health -= theDamage;
		if (health <= 0)
		{
			Dead();
		}
	}
    public void Dead()
    {
        Destroy(gameObject);
    }
}
