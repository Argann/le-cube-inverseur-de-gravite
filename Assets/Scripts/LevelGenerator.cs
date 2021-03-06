﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelGenerator : MonoBehaviour {

    [SerializeField]
    private GameObject[] platformList;

    public static float Speed = 1;

    [SerializeField]
    private GameObject item;

    [SerializeField]
    private GameObject startingItemUp;

    [SerializeField]
    private GameObject startingItemDown;

    private bool lastSpawnIsUp;


    public void Start()
    {
        this.lastSpawnIsUp = false;
        StartCoroutine("SpawnItem");
        GeneratePlatform();
        Time.timeScale = 1f;
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

    //public void SpawnUp()
    //{
    //    GameObject platform = Instantiate(this.platformListUp[Random.Range(0, this.platformListUp.Length)]);
    //    platform.transform.position = this.startingPointUp.transform.position;
    //}

    //public void SpawnDown()
    //{
    //    GameObject platform = Instantiate(this.platformListDown[Random.Range(0, this.platformListDown.Length)]);
    //    platform.transform.position = this.startingPointDown.transform.position;
    //}

    //public void GeneratePlatform()
    //{
    //    if (this.lastSpawnIsUp)
    //    {
    //        this.lastSpawnIsUp = !this.lastSpawnIsUp;
    //        SpawnDown();
    //    } else
    //    {
    //        this.lastSpawnIsUp = !this.lastSpawnIsUp;
    //        SpawnUp();
    //    }

    //}

    public void GeneratePlatform()
    {
        GameObject nextPlatform = Instantiate(this.platformList[Random.Range(0, this.platformList.Length)]);
        nextPlatform.transform.position = (Vector2)this.transform.position + new Vector2(nextPlatform.GetComponent<BoxCollider2D>().size.x / 2, 0);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("MainLevel");
    }

    public void OnClick_Retour()
    {
        SceneManager.LoadScene("Menu");
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Platform")
        {
            this.GeneratePlatform();
        }
    }
}
