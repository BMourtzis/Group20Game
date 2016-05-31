using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour {

    [SerializeField]
    GameObject[] weapons;

    // Use this for initialization
    void Start ()
    {
        int initialAmmo = 0;
	    for(int i = 0; i < weapons.Length && weapons[i] != null; i++)
        {
            weapons[i].GetComponent<WeaponScript>().Disable();
            switch(i)
            {
                case 0:
                    initialAmmo = 48;
                    break;
                case 1:
                    initialAmmo = 100;
                    break;
                case 2:
                    initialAmmo = 0;
                    break;
                case 3:
                    initialAmmo = 0;
                    break;
                case 4:
                    initialAmmo = 0;
                    break;

            }
            weapons[i].GetComponent<WeaponScript>().setAmmo(initialAmmo);
        }
	}
}
