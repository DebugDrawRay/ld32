using UnityEngine;
using System.Collections;

public class BirdBullet : MonoBehaviour {
	public float speed;

	public Vector3 direct;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Rigidbody> ().velocity = direct * speed * Time.deltaTime;
	}
}
