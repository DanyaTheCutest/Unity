using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerAudioEvents : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private AudioClip _shot;
    [SerializeField] private AudioClip _died;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _player.Died += OnDied;
        _player.Shooting += OnShoting;
    }

    private void OnDisable()
    {
        _player.Died -= OnDied;
        _player.Shooting -= OnShoting;
    }

    private void OnDied()
    {
        _audioSource.PlayOneShot(_died);
    }

    private void OnShoting()
    {
        _audioSource.PlayOneShot(_shot);
    }

}
