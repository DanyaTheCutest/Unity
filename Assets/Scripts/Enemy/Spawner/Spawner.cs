using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] public List<Wave> _waves;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Player _player;

    private Wave _currentWave;
    private int _currentWaveNumber;
    private float _lastSpawnTime;
    private int _spawned;
    private int _killed;

    public event UnityAction AllEnemyDied;
    public event UnityAction AllWavesCompleted;

    private void Start()
    {
        _currentWave = null;
    }

    private void Update()
    {

        if (_currentWave == null)
            return;

        if (_spawned < _currentWave.Volume)
        {
            _lastSpawnTime += Time.deltaTime;

            if (_lastSpawnTime >= _currentWave.Delay)
            {
                InstantiateEnemy();
                _spawned++;
                _lastSpawnTime = 0;
            }
        }
        

        if (_spawned >= _currentWave.Volume)
        {
            if (_spawned == _killed)
            {
                _currentWave = null;

                if (_waves.Count >= _currentWaveNumber + 1)
                    AllEnemyDied?.Invoke();
                else
                    AllWavesCompleted?.Invoke();
            }
        }
    }

    private void InstantiateEnemy()
    {
        Enemy enemy = Instantiate(_currentWave.Template, _spawnPoint.position, Quaternion.identity, _spawnPoint);
        enemy.Init(_player);
        enemy.Dying += OnEnemyDying;
    }

    public void NextWave()
    {
        _currentWave = _waves[_currentWaveNumber++];
        _spawned = 0;
        _killed = 0;
        _lastSpawnTime = _currentWave.Delay;
    }

    private void OnEnemyDying(Enemy enemy)
    {
        _killed++;
        _player.AddMoney(enemy.Reward);
        enemy.Dying -= OnEnemyDying;
    }
}