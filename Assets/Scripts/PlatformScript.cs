using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlatformScript : MonoBehaviour {

    public float secondsBeforeDestroy;

    public LevelGenerator levelGenerator;

    void Start()
    {
        Destroy(this.gameObject, this.secondsBeforeDestroy);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        levelGenerator.GeneratePlatform();
    }

    

}
