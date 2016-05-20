using UnityEngine;
using System.Collections;

public class CameraRotationScript : MonoBehaviour {

    [SerializeField]
    bool CameraRotation;

    private Vector3 CamRot;

	// Use this for initialization
	void Start () {
        CamRot = transform.rotation.eulerAngles;
    }
	
	// Update is called once per frame
	void Update () {
        if(CameraRotation)
        {
            CamRot.z += .5f;
            transform.rotation = Quaternion.Euler(CamRot);
        }
    }
}
