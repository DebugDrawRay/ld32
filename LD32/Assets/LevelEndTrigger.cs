using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelEndTrigger : MonoBehaviour {
	public string levelToLoad;
    public PausingMaster pMaster;
    public Image fade;
    public float fadeTime;
    public Color targetColor;

    private bool endScene;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(endScene)
        {
            fade.color = Color.Lerp(fade.color, targetColor, fadeTime);
            if(fade.color.a >= .99)
            {
                ChangeScene();
            }
        }
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
            endScene = true;
		}
	}

	void ChangeScene() 
    {
            Application.LoadLevel(levelToLoad);
	}
}
