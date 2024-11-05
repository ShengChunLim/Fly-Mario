using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is responsible for spawning mushroom objects at regular intervals.
public class MushroomSpawner : MonoBehaviour
{
    // Reference to the Mushroom prefab that will be instantiated.
    [SerializeField] private GameObject[] mushroomList;
    // Time delay before the first mushroom spawns.
    [SerializeField] private float spawnMushroomTime = 1.0f;
    // Time interval between subsequent mushroom spawns.
    [SerializeField] private float spawnMushroomRate = 1.0f;

    // Start is called before the first frame update.
    // It starts the repeating spawn process for mushrooms.
    void Start()
    {
        // InvokeRepeating calls the "SpawnMushroom" method repeatedly.
        // It starts after 'spawnMushroomTime' seconds and repeats every 'spawnMushroomRate' seconds.
        InvokeRepeating("SpawnMushroom", spawnMushroomTime, spawnMushroomRate);
    }

    // Update is called once per frame.
    void Update()
    {

    }

    // Is it time to spawn a Mushroom.
    // This method creates a new instance of the Mushroom at the spawner's position.
    private void SpawnMushroom()
    {
        int mushroomIndex = Random.Range(0, mushroomList.Length);
        // Instantiate a new mushroom object at eh spawner's position with no rotation.
        GameObject newMushroom = Instantiate(mushroomList[mushroomIndex], transform.position, Quaternion.identity);
    }
}