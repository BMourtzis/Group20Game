using UnityEngine;
using System.Collections;

public class RotateToCursor : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		
		Vector3 mouse = Input.mousePosition;
		Vector3 obj = Camera.main.WorldToScreenPoint(transform.position);
		Vector3 offset = mouse - obj;

		float rotZ = Mathf.Atan2 (offset.y, offset.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0, 0, rotZ);
	}
}
