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
        InvokeRepeating("Fire", 0.0f, 1.0f / weapon.GetComponent<WeaponScript>().FireRate);
    }
	
	// Update is called once per frame
	void Update ()
    {
        c_Fire = false;

        if(CrossPlatformInputManager.GetAxis("Fire1") != 0)
        {
            c_Fire = true;
        }
    }

    void Fire()
    {
        if(c_Fire)
        {
            weapon.GetComponent<WeaponScript>().Fire();
        }
    }

    
}
