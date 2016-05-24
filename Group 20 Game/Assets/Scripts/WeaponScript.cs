using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {

    [SerializeField]
    GameObject Projectile;
    [SerializeField]
    int Ammo;
    [SerializeField]
    public float FireRate;
    [SerializeField]
    Transform EndOfBarrel;

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
       if(Ammo > 0)
        {
            Ammo--;
            GameObject bullet = (GameObject)Instantiate(Projectile, EndOfBarrel.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * 1000);
        }
    }

    public int getAmmo()
    {
        return Ammo;
    }
}
