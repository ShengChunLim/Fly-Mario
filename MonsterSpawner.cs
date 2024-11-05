using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is responsible for spawing monsters at random intervals and heights.
public class MonsterSpawner : MonoBehaviour
{
    // An array of GameObjects representing different types of monsters to spawn.
    [SerializeField] private GameObject[] monsterList;
    // Minimum time between monster spawns.
    [SerializeField] private float minSpawnTime = 1.0f;
    // Maximum time between monster spawns.
    [SerializeField] private float maxSpawnTime = 2.0f;
    // Minimum vertical position (height) at which a monster can be spawned.
    [SerializeField] private float minSpawnHeight = -1.9f;
    // Maximum vertical position (height) at which a monster can be spawned.
    [SerializeField] private float maxSpawnHeight = 3.9f;

    // Start() is called before the first frame update.
    // It begins the monster spawning process by calling SpawnMonster().
    void Start()
    {
        //InvokeRepeating("SpawnMonster", spawnMonsterTime, spawnMonsterRate);
        SpawnMonster();
    }

    // Update is called once per frame.
    // It's currently empty since no continuous update logic is needed for this spawner.
    void Update()
    {

    }

    // This method spawns a new monster at a random height and schedules the next spawn.
    private void SpawnMonster()
    {
        // Select a random index from the monsterList array.
        int monsterIndex = Random.Range(0, monsterList.Length);
        // Instatiate a new monster from the selected index at the spawner's position with no rotation.
        GameObject newMonster = Instantiate(monsterList[monsterIndex], transform.position, Quaternion.identity);
        // Choose a random height within the specified range for the new monster.
        float height = Random.Range(minSpawnHeight, maxSpawnHeight); // 0.5f
        // Move the new Monster to the random height above or below its current position.
        newMonster.transform.position += new Vector3(0.0f, height, 0.0f);
        // Determine a random time for the next monster spawn.
        float monsterSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        // Schedule the next call to SpawnMonster() after the calculated time.
        Invoke("SpawnMonster", monsterSpawnTime);
    }

    // Reduces the time between monster spawns by decreasing the minimum and maximum spawn times.
    public void ReduceSpawnTime()
    {
        // Multiply min and max spawn times by 0.9 to make spawns happen more frequently.
        minSpawnTime *= 0.9f;
        maxSpawnTime *= 0.9f;
    }

    // Increases the time between monster spawns by increasing the minimum and maximum spawn times.
    public void IncreaseSpawnTime()
    {
        // Divide min and max spawn times by 0.9 to make spawns happen less frequently.
        minSpawnTime /= 0.9f;
        maxSpawnTime /= 0.9f;
    }
}