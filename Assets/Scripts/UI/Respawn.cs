using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Button _button;

    private void OnEnable()
    {
        _player.Died += OnPlayerDied;
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _player.Died -= OnPlayerDied;
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnPlayerDied()
    {
        _button.gameObject.SetActive(true);
    }

    private void OnButtonClick()
    {
        _button.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
