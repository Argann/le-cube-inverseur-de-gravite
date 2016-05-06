using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlatformScript : MonoBehaviour {

    public float secondsBeforeDestroy;

    void Start()
    {
        Destroy(this.gameObject, this.secondsBeforeDestroy);
    }

    

}
