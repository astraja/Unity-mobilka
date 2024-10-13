using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static event Action<int,int,int> OnStatsChange;
    [SerializeField] Transform Enemies;
    private string key = "bulletCount";
    int enemyCount = 0;
    int enemyKilled = 0;
    int bulletCount;
    int activeScene;
    int allScenesCount;

    void AddEnemyKilled()
    {
        enemyKilled++;
        CheckGameState();
        ChangeUi();
    }

    void RemoveBullet()
    {
        bulletCount--;
        CheckGameState();
        ChangeUi();
    }

    void ChangeUi()
    {
        OnStatsChange?.Invoke(enemyKilled, enemyCount, bulletCount);
    }

    void CheckGameState()
    {
        if (enemyCount == enemyKilled)
        {
            if(allScenesCount - activeScene > 1)
            {
                SceneManager.LoadScene(++activeScene);
            }
        }

        if (bulletCount == 0)
        {
            SceneManager.LoadScene(0);
        }
    }


    void Start()
    {
        enemyCount = Enemies.childCount;
        bulletCount = enemyCount+1;
        activeScene = SceneManager.GetActiveScene().buildIndex;
        allScenesCount = SceneManager.sceneCountInBuildSettings;
        ChangeUi();
    }
    

    void Update()
    {
        
    }

    private void OnEnable()
    {
        Enemy.OnEnemyKill += AddEnemyKilled;
        Thrower.OnThrow += RemoveBullet;
    }

    private void OnDisable()
    {
        Enemy.OnEnemyKill -= AddEnemyKilled;
        Thrower.OnThrow -= RemoveBullet;
    }
}
