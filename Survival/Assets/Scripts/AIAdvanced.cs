using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAdvanced : MonoBehaviour
{
	private float Distance;
	public GameObject Target;
	public float LookAtDistance = 25.0f;
	public float AttackRange = 1.5f;
	public float ChaseRange = 15.0f;
	public float MoveSpeed = 5.0f;
	public float attackRepeatTime = 1.0f;
	private float attackTime;


	public float Damping = 6.0f;

	public CharacterController controller;
	public float gravity = 20.0f;
	private Vector3 moveDirection = Vector3.zero;

	public float theDamage = 40f;

	// Start is called before the first frame update
	void Start()
	{
		attackTime = Time.time;
	}

	// Update is called once per frame
	void Update()
	{
		Distance = Vector3.Distance(Target.transform.position, transform.position);
		//Debug.Log(Distance);

		if (Distance < LookAtDistance)
		{
			LookAt();
		}
		if (Distance > LookAtDistance)
		{
			GetComponent<Renderer>().material.color = Color.green;
		}

		if (Distance < AttackRange)
		{
			Attack();
		}
		else if (Distance < ChaseRange)
		{
			Chase();
		}
	}

	private void LookAt()
	{
		GetComponent<Renderer>().material.color = Color.yellow;
		var rotation = Quaternion.LookRotation(Target.transform.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Damping);
	}

	private void Chase()
	{
		GetComponent<Renderer>().material.color = Color.red;
		//transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);

		moveDirection = transform.forward;
		moveDirection *= MoveSpeed;

		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}

	private void Attack()
	{
		if (Time.time > attackTime)
		{
			Target.SendMessage("ApplyDamage", theDamage, SendMessageOptions.DontRequireReceiver);
			Debug.Log("The enemy has attacked");
			attackTime = Time.time + attackRepeatTime;
		}
		
	}

	public void ApplyDamage()
	{
		ChaseRange += 30;
		MoveSpeed += 2;
		LookAtDistance += 40;
	}
}
