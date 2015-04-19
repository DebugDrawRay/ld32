using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public float health;
	public bool invul;
	public float invulTime;

	public void changeHealth(float change) {
		if (!invul || change > 0) {
			health += change;
		}
	}

    public float getHealth()
    {
        return health;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (invulTime <= 0) {
			invul = false;
		} else {
			invulTime -= Time.deltaTime;
		}

		if (health <= 0f) {
			Destroy(gameObject);
		}
	}
}
