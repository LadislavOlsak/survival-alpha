using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public GameObject[] Weapons;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {

            foreach (var key in keyCodes)
            {
                if (Input.GetKeyDown(key))
                {
                    SwitchWeapon(key);
                }
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                ToogleWeapon();
            }

        }
    }

    private void ToogleWeapon()
    {
        bool lastActiveWeapon = false; 

        foreach (var weapon in Weapons)
        {
            if (Weapons.Last().activeInHierarchy && weapon != Weapons.Last())
            {
                weapon.SetActive(true);
            }
            else if (lastActiveWeapon)
            {
                weapon.SetActive(true);
                lastActiveWeapon = false;
            }
            else
            {
                if (weapon.activeInHierarchy)
                {
                    lastActiveWeapon = true;
                }
                weapon.SetActive(false);
            }
        }
    }

    private void SwitchWeapon(KeyCode kcode)
    {
        Console.WriteLine(kcode.ToString());
        foreach (var weapon in Weapons.Select((value, i) => new { i, value }))
        {
            if (((int)kcode) - 49 == weapon.i)
            {
                weapon.value.SetActive(true);
            }
            else
            {
                weapon.value.SetActive(false);
            }
        }
    }

    private KeyCode[] keyCodes = {
         KeyCode.Alpha1,
         KeyCode.Alpha2,
         KeyCode.Alpha3,
         KeyCode.Alpha4,
         KeyCode.Alpha5,
         KeyCode.Alpha6,
         KeyCode.Alpha7,
         KeyCode.Alpha8,
         KeyCode.Alpha9,
     };
}
