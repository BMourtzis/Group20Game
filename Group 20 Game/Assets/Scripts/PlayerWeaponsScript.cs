using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerWeaponsScript : MonoBehaviour {

    [SerializeField]
    float fireRate;
    [SerializeField]
    GameObject weaponObj;

    private bool c_Fire;
    GameObject weapon;
    

	// Use this for initialization
	void Start ()
    {
        weapon = (GameObject)Instantiate(weaponObj, transform.position, transform.rotation);
        weapon.transform.parent = transform;
    }
	
	// Update is called once per frame
	void Update ()
    {
        c_Fire = CrossPlatformInputManager.GetButton("Fire1");

        if(c_Fire)
        {
            weapon.GetComponent<WeaponScript>().Fire();
        }
    }

    
}
