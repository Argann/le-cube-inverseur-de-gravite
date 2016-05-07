using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelGenerator : MonoBehaviour {

    [SerializeField]
    private GameObject[] platformListUp;

    [SerializeField]
    private GameObject[] platformListDown;

    public static float Speed = 1;

    [SerializeField]
    private GameObject startingPointUp;

    [SerializeField]
    private GameObject startingPointDown;

    [SerializeField]
    private GameObject item;

    [SerializeField]
    private GameObject startingItemUp;

    [SerializeField]
    private GameObject startingItemDown;

    private bool lastSpawnIsUp;


    public void Start()
    {
        this.lastSpawnIsUp = true;
        StartCoroutine("SpawnItem");
        GeneratePlatform();
    }


    public IEnumerator SpawnItem()
    {
        while (true)
        {
            if (Random.Range(0f, 1f) <= 0.5f)
            {
                GameObject item = Instantiate(this.item);
                item.transform.position = this.startingItemUp.transform.position;
            }
            else
            {
                GameObject item = Instantiate(this.item);
                item.transform.position = this.startingItemDown.transform.position;
            }
            yield return new WaitForSeconds(Random.Range(1f, 1.5f));
        }
        
    }

    public void SpawnUp()
    {
        GameObject platform = Instantiate(this.platformListUp[Random.Range(0, this.platformListUp.Length)]);
        platform.transform.position = this.startingPointUp.transform.position;
        this.lastSpawnIsUp = true;
    }

    public void SpawnDown()
    {
        GameObject platform = Instantiate(this.platformListDown[Random.Range(0, this.platformListDown.Length)]);
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

    public void RestartLevel()
    {
        SceneManager.LoadScene("MainLevel");
    }

    public void OnClick_Retour()
    {
        SceneManager.LoadScene("Menu");
    }



}
