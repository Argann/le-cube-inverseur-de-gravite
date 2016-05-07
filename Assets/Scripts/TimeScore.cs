using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeScore : MonoBehaviour {

    public Text[] textList;

    public int score;

    public int scoreMultiplicator;

	// Use this for initialization
	void Start () {
        this.score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        this.score += (int)(Time.deltaTime*this.scoreMultiplicator);
        foreach (Text item in textList)
        {
            item.text = this.score.ToString();
        }
	}
}
