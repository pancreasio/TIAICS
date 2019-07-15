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
        gameManager.UpdateCurrent();
        gameManager.SetRetryLevel();
    }

    private void Update()
    {
        levelTime += Time.deltaTime;
        deadEnemies = 0;
        foreach (GameObject enemy in enemyArray)
        {
            if (enemy == null)
            {
                deadEnemies++;
            }
        }

        if (deadEnemies >= totalEnemies)
        {
            NextLevel();
        }
        Debug.Log("Total Enemies: " + totalEnemies + "  Dead Enemies: " + deadEnemies);
    }

    private void NextLevel()
    {
        gameManager.NextScene();
    }

    public void GameOver()
    {
        gameManager.GameOver();
    }
}