using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private string _label;
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private int _price;
    [SerializeField] private bool _isBuyed;

    public string Label => _label;
    public int Damage => _damage;
    public float Speed => _speed;
    public int Price => _price;
    public bool IsBuyed => _isBuyed;


    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
        }
        Destroy(gameObject);
    }

    public void Buy()
    {
        _isBuyed = true;
    }
}
