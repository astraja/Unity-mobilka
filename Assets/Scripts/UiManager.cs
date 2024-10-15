using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _killedTxt;
    [SerializeField] TextMeshProUGUI _bulletCountTxt;

    void UpdateUi(int enemyKilled, int enemyCount)
    {
        _killedTxt.text = $"{enemyKilled} / {enemyCount}";
    }
    void UpdateBulletUi(int bulletCount)
    {
        _bulletCountTxt.text = $"Bullets: {bulletCount}";
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    private void OnEnable()
    {
        GameManager.OnStatsChange += UpdateUi;
        Thrower.OnBulletChange += UpdateBulletUi;
    }

    private void OnDisable()
    {
        GameManager.OnStatsChange -= UpdateUi;
        Thrower.OnBulletChange -= UpdateBulletUi;
    }
}