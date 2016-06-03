using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class WeaponScript : MonoBehaviour {

    [SerializeField]
    GameObject Projectile;
    [SerializeField]
    int Ammo;
    [SerializeField]
    public float FireRate;
    [SerializeField]
    Transform EndOfBarrel;
    [SerializeField]
    float ProjectileSpeed;
    [SerializeField]
    int NumberOfProjectiles;
    [SerializeField]
    float AreaOfSpread;

    bool Enabled;

    void FixedUpdate()
    {
        Vector3 mouse = Input.mousePosition;
        Vector3 obj = Camera.main.WorldToScreenPoint(transform.parent.position);
        Vector3 offset = mouse - obj;

        float rotZ = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        Vector2 pos = new Vector2(Mathf.Cos(Mathf.Deg2Rad*rotZ), Mathf.Sin(Mathf.Deg2Rad * rotZ)-0.3f   )/3f;
        transform.localPosition = pos;

        if(rotZ > 90 || rotZ < -90)
        {
            GetComponent<SpriteRenderer>().flipY = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipY = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    public void Fire()
    {
       if(Ammo > 0 && NumberOfProjectiles > 0)
        {
            Ammo--;
            float rotation = transform.rotation.eulerAngles.z;
            float turnStep = 0;

            if(NumberOfProjectiles != 1)
            {
                rotation += AreaOfSpread / 2;
                turnStep = AreaOfSpread / (NumberOfProjectiles - 1);
                if (NumberOfProjectiles % 2 == 0)
                {
                    rotation -= turnStep / 2;
                }
            }
            for (int i = 0; i < NumberOfProjectiles; i++, rotation-= turnStep)
            {
                GameObject bullet = (GameObject)Instantiate(Projectile, EndOfBarrel.position, Quaternion.Euler(0,0,rotation));
                bullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * 100 * ProjectileSpeed);
				playGunSound ();
            }
        }
    }

	void playGunSound()
	{
		GetComponent<AudioSource> ().Play ();
	}

    public void Enable()
    {
        Enabled = true;
    }

    public void Disable()
    {
        Enabled = false;
    }
    
    public bool getEnabled()
    {
        return Enabled;
    }

    public int getAmmo()
    {
        return Ammo;
    }

    public void setAmmo(int newAmmo)
    {
        Ammo = newAmmo;
    }

    public void addAmmo(int addAmmo)
    {
        Ammo += addAmmo;
    }
}
