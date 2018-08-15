using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetup_NT : MonoBehaviour {

	public Camera cameraA;
	public Camera cameraB;

	public Material cameraMatA;
	public Material cameraMatB;

	// Use this for initialization
	void Start () {
		if (cameraA.targetTexture != null) {
			cameraA.targetTexture.Release();	// remove the texture
		}

		// create a new texture at run time.
		cameraA.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);

		// can feed this texture on to the material
		cameraMatA.mainTexture = cameraA.targetTexture;



		if (cameraB.targetTexture != null) {
			cameraB.targetTexture.Release();	// remove the texture
		}

		// create a new texture at run time.
		cameraB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);

		// can feed this texture on to the material
		cameraMatB.mainTexture = cameraB.targetTexture;
	}
}
