using UnityEngine;
using System.Collections;

public class PlatformScript : MonoBehaviour {

    public float secondsBeforeDestroy;

    private bool hasGenerated = false;

    void Start()
    {
        Destroy(this.gameObject, this.secondsBeforeDestroy);
    }

    void Update()
    {
        this.transform.position += Vector3.left * Time.deltaTime * LevelGenerator.Speed * 6;
    }
}
