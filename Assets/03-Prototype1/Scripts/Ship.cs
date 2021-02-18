using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [Header("Set in Inspector")]

    // Prefab for instantiating missiles
    public GameObject missilePrefab;

    // Speed at which the ship moves
    public float speed = 1f;

    // Distance where ship turns around
    public float leftAndRightEdge = 20f;

    // Chance that the ship will change di
    public float chanceToChangeDirections = 0.1f;

    // Rate at which missiles will be instantiated
    public float secondsBetweenMissileDrops = 1f;

    // Start is called before the first frame update
    void Start()
    {
        // Dropping missiles every second
        InvokeRepeating("DropMissile", 2f, secondsBetweenMissileDrops);
    }
    void DropMissile()
    {
        GameObject missile = Instantiate(missilePrefab) as GameObject;
        missile.transform.position = transform.position;
    }
        // Update is called once per frame
        void Update()
    {
        // Movements and direction changes
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); // Moves right
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); // Moves left
        }
    }
    void FixedUpdate()
    {
        // Changes Directions Randomly
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1; // Changes Directions
        }
    }
}
