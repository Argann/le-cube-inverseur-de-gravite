using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class TimeScore : MonoBehaviour {

    public Text[] textList;

    public int score;

    public int scoreItem;

    public int scoreMultiplicator;

    public AudioClip soundItem;

    public bool isPlaying;

	// Use this for initialization
	void Start () {
        this.score = 0;
        this.isPlaying = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (isPlaying)
        {
            this.score += (int)(Time.deltaTime * this.scoreMultiplicator);
            foreach (Text item in textList)
            {
                item.text = this.score.ToString();
            }
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.gameObject.tag == "ScoreItem")
        {
            Time.timeScale += 0.05f;
            this.score += this.scoreItem;
            if (PlayerPrefs.GetInt("sons", 1) == 1)
            {
                GetComponent<AudioSource>().PlayOneShot(this.soundItem);
            }
            Destroy(col.gameObject);
        }
    }
}
