using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AmmoTextScript : MonoBehaviour
{
	
	// Update is called once per frame
	void Update ()
    {
        int ammo = GameObject.FindGameObjectWithTag("Weapon").GetComponent<WeaponScript>().getAmmo();
        GetComponent<Text>().text = "Ammo: " + ammo;
	}
}
