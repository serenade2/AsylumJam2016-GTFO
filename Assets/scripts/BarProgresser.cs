using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BarProgresser : MonoBehaviour
{

    private Image _image;
    private RectTransform _canvasRectTransform;
    private RectTransform _rectTransform;
    public float AlphaIncreaseBySecond = 2.0f;

    void Awake()
    {
        _image = GetComponent<Image>();
        _canvasRectTransform = transform.parent.GetComponent<RectTransform>();
        _rectTransform = GetComponent<RectTransform>();
    }

    public void SetPosition(Vector3 position)
    {
        Vector2 viewportPosition = Camera.main.WorldToViewportPoint(position);

        _rectTransform.anchoredPosition = new Vector2(
            viewportPosition.x * _canvasRectTransform.rect.size.x,
            viewportPosition.y * _canvasRectTransform.rect.size.y);
    }

    public void SetFillAmount(float value)
    {
        _image.fillAmount = value;
    }

    public void Update()
    {
        if (_image.fillAmount > 0.0f)
            _image.color = new Color(_image.color.r, _image.color.g, _image.color.b,
                _image.color.a + Time.deltaTime * AlphaIncreaseBySecond);
        else
           _image.color = new Color(_image.color.r, _image.color.g, _image.color.b,
                0.0f);
    }
}
