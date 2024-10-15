using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static event Action<int, int> OnStatsChange;
    [SerializeField] Transform _enemiesContainer;

    int _enemyCount = 0;
    int _enemyKilled = 0;

    int _activeScene;
    int _allScenesCount;

    void Start()
    {
        _enemyCount = _enemiesContainer.childCount;
        _activeScene = SceneManager.GetActiveScene().buildIndex;
        _allScenesCount = SceneManager.sceneCountInBuildSettings;
        CheckGameState();
    }

    void Update()
    {

    }

    void CheckGameState()
    {
        OnStatsChange?.Invoke(_enemyKilled, _enemyCount);
        if (_enemyCount == _enemyKilled)
        {
            if (_allScenesCount - _activeScene > 1)
            {
                SceneManager.LoadScene(++_activeScene);
            }
        }

    }

    void EnemyKill()
    {
        _enemyKilled++;
        CheckGameState();
    }

    void CheckBulletAmount(int bullet)
    {
        if (bullet == 0)
        {
            {
                GameOver();
            }
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene(0);
    }




    void OnEnable()
    {
        Enemy.OnEnemyKill += EnemyKill;
        Thrower.OnBulletChange += CheckBulletAmount;
    }

    void OnDisable()
    {
        Enemy.OnEnemyKill -= EnemyKill;
        Thrower.OnBulletChange -= CheckBulletAmount;
    }

}