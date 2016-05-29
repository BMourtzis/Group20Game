using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerWeaponsScript : MonoBehaviour {

    [SerializeField]
    float fireRate;

    private bool c_Fire;
    GameObject weapon;
    

	// Use this for initialization
	void Start ()
    {
        if(weapon != null)
        {
            InvokeRepeating("Fire", 0.0f, 1.0f / weapon.GetComponent<WeaponScript>().FireRate);
        }
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

    public void ReplaceWeapon(WeaponObject newWeapon)
    {
        weapon = (GameObject)Instantiate(newWeapon.getWeapon(), transform.position, transform.rotation);
        weapon.transform.parent = transform;
        InvokeRepeating("Fire", 0.0f, 1.0f / weapon.GetComponent<WeaponScript>().FireRate);
    }

    void Fire()
    {
        if(c_Fire)
        {
            weapon.GetComponent<WeaponScript>().Fire();
        }
    }

    
}
