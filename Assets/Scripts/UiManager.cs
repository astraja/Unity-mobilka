using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _enemiesCountTxt;
    [SerializeField] TextMeshProUGUI _bulletCountTxt;

    public void OnEnemyUpdate(int enemiesCount)
    {
        _enemiesCountTxt.text = enemiesCount.ToString();
    }


    public void QuitApp()
    {
        Application.Quit();
    }

    public void OnBulletUpdate(int bulletIndex)
    {
        _bulletCountTxt.text = $"{bulletIndex}";
    }
}