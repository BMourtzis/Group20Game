using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerWeaponsScript : MonoBehaviour
{
    public float fireRate;

    GameObject weapon;
    float frameTime;
    float fps;

	// Update is called once per frame
	void Update ()
    {
        if(Input.GetButton("Fire1") && weapon != null)
        {
            Fire();
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
        fps = 1.0f / weapon.GetComponent<WeaponScript>().FireRate;

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
        float dTime = Time.time - frameTime;
        if(dTime >= fps)
        {
            weapon.GetComponent<WeaponScript>().Fire();
            frameTime = Time.time;
        }
    }

    
}
