using UnityEngine;
using System.Collections;

public class LevelGenerator : MonoBehaviour {

    [SerializeField]
    private GameObject[] platformList;

    [SerializeField]
    private float platformSpeed;

    [SerializeField]
    private GameObject startingPointUp;

    [SerializeField]
    private GameObject startingPointDown;

    private bool lastSpawnIsUp;


    public void Start()
    {
        this.lastSpawnIsUp = true;
        GeneratePlatform();
    }

    public void SpawnUp()
    {
        GameObject platform = Instantiate(this.platformList[Random.Range(0, this.platformList.Length)]);
        platform.transform.position = this.startingPointUp.transform.position;
        platform.GetComponent<Rigidbody2D>().velocity = Vector2.left * platformSpeed;
        this.lastSpawnIsUp = true;
    }

    public void SpawnDown()
    {
        GameObject platform = Instantiate(this.platformList[Random.Range(0, this.platformList.Length)]);
        platform.transform.position = this.startingPointDown.transform.position;
        platform.GetComponent<Rigidbody2D>().velocity = Vector2.left * platformSpeed;
        this.lastSpawnIsUp = false;
    }

    public void GeneratePlatform()
    {
        if (this.lastSpawnIsUp)
        {
            SpawnDown();
        } else
        {
            SpawnUp();
        }
    }





}
