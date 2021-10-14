﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject[] projectiles = null;
    public GameObject player = null;
    public GameObject[] Spawners = null;
    public GameObject spawner1 = null, spawner2 = null, spawner3 = null;

    Vector3 dir = Vector3.zero;
    Vector3 dir2 = Vector3.zero;
    Vector3 dir3 = Vector3.zero;

    public float speed = 25f;
    public float velocity = 500f;

    
    public Text score = null;
    public List<GameObject> foodStore = new List<GameObject>();
    public int maxFood = 0;

    public CameraMovement cameraPlayer = null;

    // Start is called before the first frame update
    void Start()
    {
        dir = player.transform.position - transform.position;
        dir2 = player.transform.position - spawner2.transform.position;
        dir3 = player.transform.position - spawner3.transform.position;
        score.enabled = true;
        cameraPlayer.GetComponent<CameraMovement>();
        


    }

    // Update is called once per frame
    void Update()
    {
        score.text = cameraPlayer.Score + "";

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject food = Instantiate(projectiles[Random.Range(0, projectiles.Length)], Spawners[Random.Range(0, Spawners.Length)].transform.position, transform.rotation);

            food.GetComponent<Rigidbody>().AddForce(dir * speed + Vector3.up * velocity);

        }

        if (maxFood < 20)
        {
            SpawnFood();
            maxFood++;
        }
        

        if (cameraPlayer.health <= 0)
        {
            
            SceneManager.LoadScene(0);
        }
        
    }

    void SpawnFood()
    {

    }
    


    IEnumerator FoodRate()
    {

        yield return new WaitForSeconds(2f);
        //for (foodStore < 10)
        //{

        //}
        GameObject food = Instantiate(projectiles[Random.Range(0, projectiles.Length)], Spawners[Random.Range(0, Spawners.Length)].transform.position, transform.rotation);
        foodStore.Add(food);
        //if(foodStore = 20)
        //{

        //}
        food.GetComponent<Rigidbody>().AddForce(dir2 * speed);

    }
    
}
