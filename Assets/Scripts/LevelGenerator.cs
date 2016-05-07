using UnityEngine;
using System.Collections;

public class LevelGenerator : MonoBehaviour {

    [SerializeField]
    private GameObject[] platformList;

    [SerializeField]
    private float platformSpeed;

    public float PlatformSpeed
    {
        get { return platformSpeed; }
        set { platformSpeed = value; }
    }


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
        this.lastSpawnIsUp = true;
    }

    public void SpawnDown()
    {
        GameObject platform = Instantiate(this.platformList[Random.Range(0, this.platformList.Length)]);
        platform.transform.position = this.startingPointDown.transform.position;
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
