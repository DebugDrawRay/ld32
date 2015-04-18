using UnityEngine;
using System.Collections;

public class CardResourceLoader : MonoBehaviour {
	public Texture2D Get2DCardReference(string cardname){
		Texture2D output = (Texture2D) Resources.Load ("2D/" + cardname);
		return output;
	}
	
	public Material Get3DCardReference(string cardname){
		return (Material) Resources.Load ("3D/" + cardname);
	}
}
