using UnityEngine;
using System.Collections;

public class LevelGenerator : MonoBehaviour {

    [SerializeField]
    private GameObject platform;

    [SerializeField]
    private float platformSpeed;

    [SerializeField]
    private Vector2 startingPointUp;

    [SerializeField]
    private Vector2 startingPointDown;

    [SerializeField]
    [Range(0.0f, 1.0f)]
    private float chanceUp;

    public void Start()
    {
        InvokeRepeating("GeneratePlatform", 0f, 0.1f);
    }

    public void GeneratePlatform()
    {
        GameObject platform = Instantiate(this.platform);
        if (Random.Range(0.0f, 1.0f) <= this.chanceUp)
        {
            platform.transform.position = this.startingPointUp;
            platform.GetComponent<Rigidbody2D>().velocity = Vector2.left * platformSpeed;
        } else
        {
            platform.transform.position = this.startingPointDown;
            platform.GetComponent<Rigidbody2D>().velocity = Vector2.left * platformSpeed;
        }
    }





}
