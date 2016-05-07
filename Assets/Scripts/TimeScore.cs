using UnityEngine;
using System.Collections;

public class TimeScore : MonoBehaviour {

    public int score;

    public int scoreMultiplicator;

	// Use this for initialization
	void Start () {
        this.score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        this.score += (int)(Time.deltaTime*this.scoreMultiplicator);
	}
}
