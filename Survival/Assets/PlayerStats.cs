using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
	public int maxHealth = 100;
	public int health;
	public RespawnMenu respawnMenu;
	public GameObject weapons;

	// Start is called before the first frame update
	void Start()
    {
		health = maxHealth;
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
		respawnMenu.playerIsDead = true;
		Debug.Log("Player Died");
		weapons.SetActive(false);	
	}

	public void RespawnStats()
	{
		health = maxHealth;
		weapons.SetActive(true);
	}
}
