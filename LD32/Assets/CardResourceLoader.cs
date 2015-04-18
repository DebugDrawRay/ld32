using UnityEngine;
using System.Collections;

public class CardResourceLoader : MonoBehaviour {
	public Sprite Get2DCardReference(string cardname){
		return (Sprite) Resources.Load ("2D/" + cardname);
	}
	
	public Material Get3DCardReference(string cardname){
		return (Material) Resources.Load ("3D/" + cardname);
	}
}
