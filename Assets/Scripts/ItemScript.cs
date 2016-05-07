using UnityEngine;
using System.Collections;

public class ItemScript : MonoBehaviour {

    public float secondsBeforeDestroy;

    public LevelGenerator levelGenerator;

    void Start()
    {
        Destroy(this.gameObject, this.secondsBeforeDestroy);
    }

    void Update()
    {
        this.transform.position += Vector3.left * Time.deltaTime * LevelGenerator.Speed*6;
    }
}
