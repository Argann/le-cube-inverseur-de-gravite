using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour {

    [SerializeField]
    private Toggle musique;
    [SerializeField]
    private Toggle sons;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void OnValueChanged_Musique()
    {
        PlayerPrefs.SetInt("musique", musique.)
    }
}
