using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {

    [SerializeField]
    GameObject Projectile;
    [SerializeField]
    int Ammo;
    [SerializeField]
    float FireRate;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void Fire()
    {
        Ammo--;
        GameObject bullet = (GameObject)Instantiate(Projectile, transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce((Vector2.right * 1000) );  
    }
}
