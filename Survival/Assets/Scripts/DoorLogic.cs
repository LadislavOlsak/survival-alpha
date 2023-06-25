using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLogic : MonoBehaviour
{
	public Transform theDoor;
    private bool drawGUI = false;
	private bool doorIsClosed = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (drawGUI && Input.GetKeyDown(KeyCode.E))
        {
			ChangeDoorState();

		}
    }

	private void ChangeDoorState()
	{
		if (doorIsClosed)
		{
			theDoor.GetComponent<Animator>().SetTrigger("openDoor");
			//theDoor.GetComponent<AudioSource>().Play();

			doorIsClosed = false;
			StartCoroutine(DoorShutAuto(3));
		}
	}

	private IEnumerator DoorShutAuto(int seconds)
	{
		yield return new WaitForSeconds(seconds);

		theDoor.GetComponent<Animator>().SetTrigger("closeDoor");
		//theDoor.GetComponent<AudioSource>().Play();

		doorIsClosed = true;
	}

	public void OnTriggerEnter(Collider theCollider)
	{
        if (theCollider.tag == "Player")
        {
			drawGUI = true;

		}
	}

	public void OnTriggerExit(Collider theCollider)
	{
		if (theCollider.tag == "Player")
		{
			drawGUI = false;

		}
	}

	public void OnGUI()
	{
        if (drawGUI)
            GUI.Box(new Rect(Screen.width / 2 - 51, Screen.height / 1.5f - 11, 102, 22), "Press E to open");
	}
}
