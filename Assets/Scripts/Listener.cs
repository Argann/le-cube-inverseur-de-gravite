using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Listener : MonoBehaviour {

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.R)) {
			SceneManager.LoadScene ("MainLevel");
		}
	}
}
