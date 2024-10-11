using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI KilledTxt;
    int enemyCount = 0;
    int enemyKilled = 0;

    void AddEnemyCount()
    {
        enemyCount++;
        UpdateEnemyStats();
    }

    void AddEnemyKilled()
    {
        enemyKilled++;
        UpdateEnemyStats();
    }
    private void OnEnable()
    {
        Enemy.OnEnemyCreate += AddEnemyCount;
        Enemy.OnEnemyKill += AddEnemyKilled;
    }

    private void OnDisable()
    {
        Enemy.OnEnemyCreate -= AddEnemyCount;
        Enemy.OnEnemyKill -= AddEnemyKilled;
    }

    void UpdateEnemyStats()
    {
        KilledTxt.text = $"{enemyKilled} / {enemyCount}";
        if(enemyCount == enemyKilled)
        {
            //Go to the next level
        }
    }
}
