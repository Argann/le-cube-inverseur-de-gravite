using UnityEngine;
using System.Collections;

public class QbeBehaviour : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidbody2D;
    [SerializeField]
    private float jumpForce;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	    if (Input.GetKeyDown(KeyCode.Space))
	    {
	        this.rigidbody2D.AddForce(Vector2.up * this.jumpForce);
	    }
	}
}
