using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class QbeBehaviour : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private BoxCollider2D bc2d;
    private SpriteRenderer sprite;
    //Puissance du saut
    [SerializeField]
    private float jumpForce;
    //Il faut qu'il saute
    private bool jump;
    //Il est au sol
    private bool grounded;
    //La gravité est inversée
    private bool gravity_reverse;
    

    // Use this for initialization
    void Start () {
        jump = false;
        grounded = false;
        gravity_reverse = false;

        rb2d = GetComponent<Rigidbody2D>();
        bc2d = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
	}

    // Update is called once per frame
    void Update()
    {
        //On vérifie si le joueur est bien au sol
        grounded = Physics2D.Linecast(transform.position, transform.position + Vector3.down * (this.rb2d.gravityScale < 0 ? -1 : 1), 1 << LayerMask.NameToLayer("Ground"));
        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }
        else if (Input.GetButtonDown("Reverse Gravity") && grounded)
        {
            gravity_reverse = true;
        }
    }

    void FixedUpdate()
    {
        if (jump)
        {
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
        if (gravity_reverse)
        {
            this.rb2d.gravityScale *= -1;
            sprite.flipY = !sprite.flipY;
            gravity_reverse = false;
        }
    }
}
