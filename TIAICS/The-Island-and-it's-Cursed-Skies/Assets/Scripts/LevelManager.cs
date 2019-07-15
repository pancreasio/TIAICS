using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Text scoreText;
    public bool levelEnded;
    private float lastWaveTime, levelTime;
    private int deadEnemies, totalEnemies;
    private GameManager gameManager;
    private GameObject[] enemyArray;
    private List<GameObject> enemyList;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        enemyArray = GameObject.FindGameObjectsWithTag("Enemy");
        totalEnemies = enemyArray.Length;
        deadEnemies = 0;
        Cursor.visible = false;
    }

    private void Update()
    {
        levelTime += Time.deltaTime;
        foreach (GameObject enemy in enemyArray)
        {
            Destroy(enemy.gameObject);
            if (enemy == null)
            {
                deadEnemies++;
            }
        }
        Debug.Log("Total Enemies: " + totalEnemies + "  Dead Enemies" + deadEnemies);
    }
}