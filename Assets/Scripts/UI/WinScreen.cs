using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private CanvasGroup winScreenGroup;
    [SerializeField] private Tower tower;
    [SerializeField] private Button NextLevel;

    private void OnEnable()
    {
        tower.OnTowerDistroyed += OnTowerDistroyed;
        NextLevel.onClick.AddListener(OnNextLevelButtonClick);
    }
    private void OnDisable()
    {
        tower.OnTowerDistroyed -= OnTowerDistroyed;
        NextLevel.onClick.RemoveListener(OnNextLevelButtonClick);
    }
    private void OnTowerDistroyed()
    {
        winScreenGroup.alpha = 1f;
        winScreenGroup.interactable = true;
        Time.timeScale = 0f;
    }
    private void OnNextLevelButtonClick()
    { 
        SceneManager.LoadSceneAsync(0);
        Time.timeScale = 1f;
    }
}
