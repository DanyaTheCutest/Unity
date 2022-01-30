using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EndGame : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Transform _endPanel;
    [SerializeField] private Transform _target;
    [SerializeField] private float _time;
    [SerializeField] private Button _quitButton;

    private void OnEnable()
    {
        _spawner.AllWavesCompleted += OnAllWavesCompleted;
        _quitButton.onClick.AddListener(OnButtonClicked);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            OnButtonClicked();
    }

    private void OnAllWavesCompleted()
    {
        _endPanel.DOMove(_target.position, _time);
    }

    private void OnButtonClicked()
    {
        Application.Quit();
    }

}
