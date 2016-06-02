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

    public GameObject ReplaceWeapon(GameObject newWeapon)
    {
        GameObject oldWeapon = null;
        if(weapon != null)
        {
            RemoveWeapon();
            oldWeapon = weapon;
        }

        weapon = (GameObject)Instantiate(newWeapon, transform.position, transform.rotation);
        weapon.transform.parent = transform;
        CancelInvoke();
        InvokeRepeating("Fire", 0.0f, 1.0f / newWeapon.GetComponent<WeaponScript>().FireRate);

        return oldWeapon;
    }

    public void addAmmo(int addAmmo)
    {
        weapon.GetComponent<WeaponScript>().addAmmo(addAmmo);
    }

    void RemoveWeapon()
    {
        Destroy(weapon);
    }

    void Fire()
    {
        if(c_Fire)
        {
            weapon.GetComponent<WeaponScript>().Fire();
        }
    }

    
}
