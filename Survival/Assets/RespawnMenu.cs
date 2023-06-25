using UnityEngine;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnMenu : MonoBehaviour
{
    public FirstPersonController fpsController;
	public StarterAssetsInputs inputController;
	public bool playerIsDead = false;
	public GameObject respawnMenu;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (playerIsDead)
		{
			fpsController.enabled = false;
		}
	}

    void OnGUI()
    {
        if (playerIsDead)
        {
			respawnMenu.SetActive(true);
			inputController.cursorLocked = false;
			//if (GUI.Button(new Rect(Screen.width * 0.5f - 50, 200 - 20, 100, 40), "Respawn"))
			//	PlayerRespawn();

			//if (GUI.Button(new Rect(Screen.width * 0.5f - 50, 250 - 20, 100, 40), "Menu"))
			//	Debug.Log("Menu");
		}
        
	}

	public void PlayerRespawn()
	{
        Debug.Log("Respawn player");
	}

	public void PlayerMenu()
	{
		Debug.Log("Menu");
	}
}
