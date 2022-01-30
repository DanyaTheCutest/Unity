using UnityEngine;
using UnityEngine.UI;

public class NextWave : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Button _button;

    private void OnEnable()
    {
        _spawner.AllEnemyDied += OnAllEnemySpawned;
        _button.onClick.AddListener(OnNextWaveButtonClick);
    }

    private void OnDisable()
    {
        _spawner.AllEnemyDied -= OnAllEnemySpawned;
        _button.onClick.RemoveListener(OnNextWaveButtonClick);
    }

    private void OnAllEnemySpawned()
    {
        _button.gameObject.SetActive(true);
    }

    private void OnNextWaveButtonClick()
    {
        _spawner.NextWave();
        _button.gameObject.SetActive(false);
    }

}
