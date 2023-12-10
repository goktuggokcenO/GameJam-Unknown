using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int whichEnemy;
    public GameObject enemy;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject player;
    private Transform spawnPosition;
    private int enemyNumberPerWave = 4;
    public int waveNumber = 0;
    public int enemysAlive = 0;
    private bool isCountdownInProgress = false;

    public float countdownTime = 5f;

    Vector3 topLeftCorner = new Vector3(10, 3, 0);
    Vector3 topRightCorner = new Vector3(40, 3, 0);
    Vector3 bottomLeftCorner = new Vector3(10, -3, 0);
    Vector3 bottomRightCorner = new Vector3(40, -3, 0);
    Vector3 randomPoint;


    // Start is called before the first frame update
    void Start()
    {
        startWave(waveNumber);

    }

    // Update is called once per frame
    void Update()
    {
        if (enemysAlive < 1 && !isCountdownInProgress)
        {
            StartCoroutine(StartCountdown());
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            enemysAlive--;
        }
    }

    

    Vector3 GetRandomPointInRectangularArea()
    {
        // Generate random coordinates within the rectangular area
        float randomX = Random.Range(bottomLeftCorner.x, topRightCorner.x);
        float randomY = Random.Range(bottomLeftCorner.y, topRightCorner.y);

        // Create a Vector2 representing the random point
        Vector3 randomPoint = new Vector3(randomX, randomY, 0);

        return randomPoint;
    }

    void spawnEnemy()
    {
        whichEnemy = Random.Range(1, 5);
        randomPoint = GetRandomPointInRectangularArea();
        spawnPosition = gameObject.transform;
        switch (whichEnemy)
        {
            case 1:
                Instantiate(enemy, randomPoint, Quaternion.identity);
                enemy.GetComponent<EnemyAI>().player = player;
                break;
            case 2:
                Instantiate(enemy2, randomPoint, Quaternion.identity);
                enemy2.GetComponent<EnemyAI>().player = player;
                break;
            case 3:
                Instantiate(enemy3, randomPoint, Quaternion.identity);
                enemy3.GetComponent<EnemyAI>().player = player;
                break;
            case 4:
                Instantiate(enemy4, randomPoint, Quaternion.identity);
                enemy4.GetComponent<EnemyAI>().player = player;
                break;
        }
        enemysAlive += 1;
    }

    void startWave(int wave)
    {

        for (int i = 0; i < (enemyNumberPerWave); i++) 
        {
            spawnEnemy();
        }
        enemyNumberPerWave += 2;
    }

    IEnumerator StartCountdown()
    {
        isCountdownInProgress = true;

        yield return new WaitForSeconds(15f);

        // Example: Start the next wave
        waveNumber++;
        startWave(waveNumber);

        // Reset the countdown time
        countdownTime = 5f;

        isCountdownInProgress = false;
    }
}
