using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _killedTxt;
    [SerializeField] TextMeshProUGUI _bulletCountTxt;

    void UpdateUi(int enemyKilled, int enemyCount, int bulletCount)
    {
        _killedTxt.text = $"{enemyKilled} / {enemyCount}";
        _bulletCountTxt.text = $"Bullets: {bulletCount}";
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