using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{ 
    public static int EnemiesAlive = 0;
    public Wave[] waves;
  public Transform spawnPoint;
  public float timeBetweenWaves = 5f;
  private float countdown = 2f;

  public TextMeshProUGUI waveCountDownText;

  public GameManager gameManager;
  
  private int waveIndex = 0;


  void Update()
  {
      if (EnemiesAlive > 0)
      {
          return;
      }
      
      if (countdown <= 0)
      {
          StartCoroutine(SpawnWave());
          countdown = timeBetweenWaves;
          return;
      }

      countdown -= Time.deltaTime;

      countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

      waveCountDownText.text = string.Format("{0:00.00}", countdown);
  }

  IEnumerator SpawnWave()
  {
      PlayerStats.Rounds++;

      Wave wave = waves[waveIndex];
      
      for (int i = 0; i < wave.count; i++)
      {
          SpawnEnemy(wave.enemy);
          yield return new WaitForSeconds(1f/wave.rate);
      }
      waveIndex++;

      if (waveIndex == waves.Length)
      {
          gameManager.WinLevel();
          this.enabled = false;
      }
  }

  void SpawnEnemy(GameObject enemy)
  {
      Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
      EnemiesAlive++;
  }
  
}
