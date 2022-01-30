using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class BulletView : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Button _sellButton;

    private Bullet _bullet;
    private SpriteRenderer _spriteRenderer;

    public event UnityAction<Bullet, BulletView> SellButtonClick;

    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnButtonClick);
        _sellButton.onClick.AddListener(TryLockBullet);
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnButtonClick);
        _sellButton.onClick.RemoveListener(TryLockBullet);
    }

    public void Render(Bullet bullet)
    {
        _bullet = bullet;

        _spriteRenderer = bullet.GetComponent<SpriteRenderer>();
        _image.sprite = _spriteRenderer.sprite;
        _image.color = _spriteRenderer.color;

        _label.text = bullet.Label;
        _price.text = bullet.Price.ToString();
    }

    private void TryLockBullet()
    {
        if (_bullet.IsBuyed)
            _sellButton.gameObject.SetActive(false);

    }

    private void OnButtonClick()
    {
        SellButtonClick?.Invoke(_bullet, this);
    }
}
