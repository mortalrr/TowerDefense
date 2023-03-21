using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

  public Transform enemyPrefab;
  public Transform spawnPoint;
  public float timeBetweenWaves = 5f;
  private float countdown = 2f;

  public TextMeshProUGUI waveCountDownText;
  
  private int waveIndex = 0;


  void Update()
  {
      if (countdown <= 0)
      {
          StartCoroutine(SpawnWave());
          countdown = timeBetweenWaves;
      }

      countdown -= Time.deltaTime;

      countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

      waveCountDownText.text = string.Format("{0:00.00}", countdown);
  }

  IEnumerator SpawnWave()
  {
      waveIndex++;
      for (int i = 0; i < waveIndex; i++)
      {
          SpawnEnemy();
          yield return new WaitForSeconds(0.5f);
      }
     
  }

  void SpawnEnemy()
  {
      Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
  }
  
}
