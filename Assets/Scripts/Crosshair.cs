using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {

	public Vector3 rawMousePos;
	public Vector3 worldMousePos;

	void Update () {
		rawMousePos = Input.mousePosition;

		worldMousePos = Camera.main.ScreenToWorldPoint (rawMousePos);
		worldMousePos.z = 0;

		this.transform.position = worldMousePos;
		//Cursor.visible = false;
		//Cursor.lockState = CursorLockMode.Confined;
	}
}
