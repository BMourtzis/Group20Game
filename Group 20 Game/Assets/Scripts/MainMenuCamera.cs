using UnityEngine;
using System.Collections;

public class MainMenuCamera : MonoBehaviour
{
    public Transform resetPoint;

    Vector3 vel;

    void Start()
    {
        vel = new Vector3(10f, 0);
    }

	// Update is called once per frame
	void Update ()
    {
        transform.position += vel*Time.deltaTime;
        if(transform.position.x > 450)
        {
            transform.position = resetPoint.position;
        }
	}
}
