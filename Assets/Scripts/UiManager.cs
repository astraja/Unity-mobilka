using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI KilledTxt;
    [SerializeField] TextMeshProUGUI BulletCount;

    void UpdateUi(int enemyKilled, int enemyCount, int bulletCount)
    {
        KilledTxt.text = $"{enemyKilled} / {enemyCount}";
        BulletCount.text = $"Bullets: {bulletCount}";
    }


    public void QuitApp()
    {
        Application.Quit();
    }

    private void OnEnable()
    {
        GameManager.OnStatsChange += UpdateUi;
    }

    private void OnDisable()
    {
        GameManager.OnStatsChange -= UpdateUi;
    }
}