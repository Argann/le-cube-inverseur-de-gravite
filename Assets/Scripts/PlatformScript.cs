using UnityEngine;
using System.Collections;

public class PlatformScript : MonoBehaviour {

    public float secondsBeforeDestroy;

    public LevelGenerator levelGenerator;

    private bool hasGenerated = false;

    void Start()
    {
        Destroy(this.gameObject, this.secondsBeforeDestroy);
    }

    void Update()
    {
        this.transform.position += Vector3.left * Time.deltaTime * LevelGenerator.Speed * 6;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "PlatformGenerator" && !hasGenerated)
        {
            hasGenerated = true;
            levelGenerator.GeneratePlatform();
        }
            
    }

    

}
