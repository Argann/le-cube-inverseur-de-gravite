﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(TimeScore))]
public class QbeBehaviour : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private BoxCollider2D bc2d;
    private SpriteRenderer sprite;

    [Header("Physique")]

    //Puissance du saut
    [SerializeField]
    private float jumpForce;
    //Il faut qu'il saute
    private bool jump;
    //Il est au sol
    private bool grounded;
    //La gravité est inversée
    private int gravity_direction;
    private bool gravity_reverse;

    [Header("Audio")]

    [SerializeField]
    private AudioClip soundJump;
    [SerializeField]
    private AudioClip soundGravity;
    [SerializeField]
    private AudioClip soundDeath;
    [SerializeField]
    private AudioSource musique;

    private AudioSource audioSource;

    [Header("UI")]

    [SerializeField]
    private GameObject gameOverUI;
    [SerializeField]
    private GameObject highscore_text;

    [Header("Background")]

    [SerializeField]
    private Transform people_flying_transform;


    // Use this for initialization
    void Start()
    {
        jump = false;
        grounded = false;
        gravity_direction = 1;
        gravity_reverse = false;
        this.audioSource = this.GetComponent<AudioSource>();
        rb2d = GetComponent<Rigidbody2D>();
        bc2d = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        this.gameOverUI.SetActive(false);
        highscore_text.SetActive(false);
        if (PlayerPrefs.GetInt("musique", 1) == 0)
        {
           musique.Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 end = transform.position + Vector3.down * (this.rb2d.gravityScale < 0 ? -1 : 1);
        float moitieLargeur = this.bc2d.size.x / 2;
        //On vérifie si le joueur est bien au sol
        bool grounded1 = Physics2D.Linecast(transform.position, end + Vector3.right * moitieLargeur, 1 << LayerMask.NameToLayer("Ground"));
        Debug.DrawRay(transform.position, end + Vector3.right * moitieLargeur);
        bool grounded2 = Physics2D.Linecast(transform.position, end + Vector3.left * moitieLargeur, 1 << LayerMask.NameToLayer("Ground"));
        Debug.DrawRay(transform.position, end + Vector3.left * moitieLargeur);
        grounded = grounded1 || grounded2;
        if (Input.GetButtonDown("Jump") && grounded)
        {
            if (PlayerPrefs.GetInt("sons", 1) == 1)
            {
                this.audioSource.PlayOneShot(this.soundJump);
            }
            jump = true;
        }
        if (Input.GetButtonDown("Reverse Gravity") && grounded)
        {
            if (PlayerPrefs.GetInt("sons", 1) == 1)
            {
                this.audioSource.PlayOneShot(this.soundGravity);
            }
            gravity_reverse = true;
        }
    }

    void FixedUpdate()
    {
        if (jump)
        {
            rb2d.AddForce(new Vector2(0f, gravity_direction * jumpForce));
            jump = false;
        }
        else if (gravity_reverse)
        {
            this.rb2d.gravityScale *= -1;
            sprite.flipY = !sprite.flipY;
            gravity_reverse = false;
            gravity_direction *= -1;
        }
        if (gravity_direction < 0)
        {
            people_flying_transform.position += Vector3.up * Time.deltaTime;
        }
        else if (people_flying_transform.position.y > 2)
        {
            people_flying_transform.position += Vector3.down * Time.deltaTime * 2;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "GameOver")
        {
            StartCoroutine("Die");
        }
    }

    public IEnumerator Die()
    {
        if (PlayerPrefs.GetInt("sons", 1) == 1)
        {
            this.audioSource.PlayOneShot(this.soundDeath);
        }
        int highscore = PlayerPrefs.GetInt("highscore", 0);
        int score = this.GetComponent<TimeScore>().score;
        if (highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
            highscore_text.SetActive(true);
        }
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.gameOverUI.SetActive(true);
        this.GetComponent<TimeScore>().isPlaying = false;
        yield return new WaitForSeconds(10.0f);
        Destroy(this.gameObject);
    }
}
