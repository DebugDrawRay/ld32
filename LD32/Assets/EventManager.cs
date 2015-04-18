using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {

	public delegate void CardAddedEvent();
	public static event CardAddedEvent CardAdded;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
