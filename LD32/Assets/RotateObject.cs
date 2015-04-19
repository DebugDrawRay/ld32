using UnityEngine;
using System.Collections;

public class RotateObject : MonoBehaviour {

	public float speed;

	public int axis;

	public Vector3 forwd;

	void Start() {
		forwd = transform.forward;
	}

	// Update is called once per frame
	void Update () {
		//Debug.Log (transform.rotation.eulerAngles.z);
		if (axis == 0) {
			transform.Rotate (forwd * Time.deltaTime * speed);
		}

		if (axis == 1) {
			transform.Rotate (Vector3.right * Time.deltaTime * speed);
		}

		if (axis == 2) {
			transform.Rotate (Vector3.forward * Time.deltaTime * speed);
		}
	}
}
