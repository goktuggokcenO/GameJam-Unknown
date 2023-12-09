using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    private Transform spawnPosition;
    private int enemyNumberPerWave = 4;
    public int waveNumber = 0;
    public int enemysAlive = 0;
    private bool isCountdownInProgress = false;

    public float countdownTime = 15f;

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
        randomPoint = GetRandomPointInRectangularArea();
        spawnPosition = gameObject.transform;
        Instantiate(enemy, randomPoint, Quaternion.identity);
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
        countdownTime = 15f;

        isCountdownInProgress = false;
    }
}
