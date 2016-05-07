using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeScore : MonoBehaviour {

    public Text text;

    public int score;

    public int scoreMultiplicator;

	// Use this for initialization
	void Start () {
        this.score = 0;
        this.text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        this.score += (int)(Time.deltaTime*this.scoreMultiplicator);
        this.text.text = this.score.ToString();
	}
}
