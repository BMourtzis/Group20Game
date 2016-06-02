using UnityEngine;
using System.Collections;

public class AmmoPackScript : ItemScript
{
    public int[] Ammo;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            for(int i =0; i<Ammo.Length; i++)
            {
                other.GetComponent<Inventory>().addAmmo(Ammo[i], i);
                Ammo[i] = 0;
            }
            Destroy(gameObject);
        }
    }
}
