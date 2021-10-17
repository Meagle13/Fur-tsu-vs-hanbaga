using System.Collections;
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
    

    public float speed = 25f;
    public float velocity = 500f;

    int foodSize = 0;
    public Text score = null;
    public List<GameObject> foodStore = new List<GameObject>();
    public int maxFood = 0;

    public CameraMovement cameraPlayer = null;

    // Start is called before the first frame update
    void Start()
    {
        dir = player.transform.position - spawner1.transform.position;
        dir2 = player.transform.position - spawner2.transform.position;
        
        score.enabled = true;
        cameraPlayer.GetComponent<CameraMovement>();
        


    }

    // Update is called once per frame
    void Update()
    {
        score.text = cameraPlayer.Score + "";

        if (maxFood < 1)
        {
            SpawnFood();
            maxFood++;
            
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        

        if (cameraPlayer.health <= 0)
        {
            
            SceneManager.LoadScene(0);
        }
        
    }

    void Spawner2()
    {
        velocity = Random.Range(450, 520);
        GameObject food = Instantiate(projectiles[Random.Range(0, projectiles.Length)], spawner2.transform.position, transform.rotation);
        foodStore.Add(food);

        food.GetComponent<Rigidbody>().AddForce(dir2 * speed + Vector3.up * velocity);
        //food.transform.position += player.transform.position * 25 * Time.deltaTime;
    }

    void Spawner1()
    {
        velocity = Random.Range(450, 500);
        GameObject food = Instantiate(projectiles[Random.Range(0, projectiles.Length)], spawner1.transform.position, transform.rotation);
        foodStore.Add(food);

        food.GetComponent<Rigidbody>().AddForce(dir * speed + Vector3.up * velocity);

        //food.transform.position += player.transform.position * 25 * Time.deltaTime;
    }

    void SpawnFood()
    {
        if (foodSize <= 20)
        {
            StartCoroutine(FoodRate());
        }
        else if (foodSize > 20)
        {
            StartCoroutine(FasterFoodRate());
        }
        
    }

    IEnumerator FasterFoodRate()
    {
        yield return new WaitForSeconds(.5f);
        var Spawn = Random.value;

        if (Spawn < 0.5)
        {
            Spawner1();
        }
        else
        {
            Spawner2();
        }

        foodSize++;
        maxFood = 0;
    }

    IEnumerator FoodRate()
    {

        yield return  new WaitForSeconds(2f);
        var Spawn = Random.value;

        if (Spawn < 0.5)
        {
            Spawner1();
        }
        else
        {
            Spawner2();
        }

        foodSize++;
        maxFood = 0;
    }
    
}
