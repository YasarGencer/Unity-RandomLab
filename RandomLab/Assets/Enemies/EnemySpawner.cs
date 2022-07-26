using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    GameCreator gameCreator;
    public GameObject[] enemies;
    void Start()
    {
        Spawn();
    }
    public void Spawn()
    {
        gameCreator = GameObject.Find("GameCreator").GetComponent<GameCreator>();
        if (gameCreator.enemies.Count < gameCreator.maxEnemyCount)
            gameCreator.enemies.Add(Instantiate(enemies[Random.Range(0, enemies.Length)], this.transform.position, Quaternion.identity));
    }
}
