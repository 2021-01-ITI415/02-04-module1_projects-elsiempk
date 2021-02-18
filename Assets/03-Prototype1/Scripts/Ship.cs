using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [Header("Set in Inspector")]
    // prefab for instantiating apples
    public GameObject MissilePrefab;

    // speed at which the ship moves
    public float speed = 1f;

    // distance where ship turns around
    public float chanceToChangeDirections = 0.1f;

    // rate at which missiles will be instantiated
    public float secondsBetweenMissileDrops = 1f;

    void Start()
    {
        // dropping missiles every second
    }

    void Update()
    {
        // basic movement
        // changing direction
    }
}
