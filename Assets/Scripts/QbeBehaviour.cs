using UnityEngine;
using System.Collections;

public class QbeBehaviour : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb2d;
    [SerializeField]
    private float jumpForce;

    //From tutorial
    private bool jump;
    private bool grounded;
    public Transform groundCheck;
    public float maxSpeed = 5f;

    // Use this for initialization
    void Start () {
	    if (rb2d == null)
        {
            rb2d = GetComponent<Rigidbody2D>();
        }
	}

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        if (jump)
        {
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
    }
}
