using UnityEngine;

[System.Serializable]

public class ParallaxLayers
{
    public float speeedX = 0.5f;
    public float speeedY = 0.2f;

    private Transform _transform;
    private Vector3 _targetPosition;

    private SpriteRenderer _sprite;
    private float _spriteWidth;
    private bool _infiniteX;

    public ParallaxLayers (Transform t)
    {
        _transform = t;
        _targetPosition = t.position;

        _sprite = t.GetComponent<SpriteRenderer>();

        if (_sprite != null)
        {
            _spriteWidth = _sprite.bounds.size.x;
            //_infiniteX = _spriteWidth > 0f;
        }

        var settings = t.GetComponent<ParallaxLayerSettings>();
        if (settings != null)
        {
            speeedX = settings.speedX;
            speeedY = settings.speedY;
        }
    }

    public void Move(Vector3 delta, bool enableVertical, float smoothing)
    {
        float moveX = delta.x * (1f - speeedX);
        float moveY = enableVertical ? delta.y * (1f - speeedY) : 0f;

        _targetPosition += new Vector3(moveX, moveY, 0f);

        _transform.position = smoothing > 0f ? Vector3.Lerp(_transform.position, _targetPosition, smoothing) : _targetPosition;

        if (_infiniteX)
        {
            WrapHorizontal();

        }
    }

    private void WrapHorizontal()
    {
        float camX = Camera.main.transform.position.x;
        float diffX = camX - _transform.position.x;

        if (Mathf.Abs(diffX) >= _spriteWidth)
        {
            float offset = diffX > 0f ? _spriteWidth : -_spriteWidth;

            _transform.position += new Vector3(offset, 0f, 0f);
        }

    }
}
