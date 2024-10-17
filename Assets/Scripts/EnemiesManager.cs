using System;
using System.Collections;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField] UiManager _uiManager;
    [SerializeField] GameManager _gameManager;
    int _enemiesCount = 0;

    void Start()
    {
        SetEnemiesValues();
        _gameManager.SetEnemiesTotal(_enemiesCount);
    }

    void SetEnemiesValues()
    {
        _enemiesCount = transform.childCount;
        _uiManager.OnEnemyUpdate(_enemiesCount);
        _gameManager.OnEnemyUpdate(_enemiesCount);
    }

    public void OnEnemyKill()
    {
        StartCoroutine(UpdateEnemyKilled());
    }

    IEnumerator UpdateEnemyKilled()
    {
        yield return new WaitForSeconds(0.05f);
        SetEnemiesValues();
    }
}
