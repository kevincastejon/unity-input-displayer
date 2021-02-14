using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputDisplayer : MonoBehaviour
{
    [Header("Reference settings")]
    [SerializeField]
    private TMP_Text _label;
    [SerializeField]
    private TMP_Text _axisValue;
    [SerializeField]
    private TMP_Text _buttonValue;
    [SerializeField]
    private Image _barBackground;
    [SerializeField]
    private RectTransform _barMask;

    [Header("Input settings")]
    [SerializeField]
    private bool _isButton;
    [SerializeField]
    [Range(0, 20)]
    private int _axisOrButtonNumber = 1;

    private Color _activeColor = new Color(1, 1, 1, 1);
    private Color _inactiveColor = new Color(1, 1, 1, 0.3f);

    // Start is called before the first frame update
    void Start()
    {
        _label.text = (!_isButton ? "Axis " : "Button ") + _axisOrButtonNumber;
    }

    // Update is called once per frame
    void Update()
    {
        float value = _isButton ? Input.GetAxisRaw("BUTTON_" + _axisOrButtonNumber) : Input.GetAxisRaw("AXIS_" + _axisOrButtonNumber);
        _axisValue.text = value.ToString("F5");
        _buttonValue.text = value > 0 ? "PRESSED" : "RELEASED";
        _barMask.localScale = new Vector3(value, 1, 1);
        ToggleType();
        ChangeColor(value != 0);
    }

    private void ToggleType()
    {
        if (_isButton)
        {
            _axisValue.gameObject.SetActive(false);
            _barBackground.gameObject.SetActive(false);
            _barMask.gameObject.SetActive(false);
            _buttonValue.gameObject.SetActive(true);
        }
        else
        {
            _axisValue.gameObject.SetActive(true);
            _barBackground.gameObject.SetActive(true);
            _barMask.gameObject.SetActive(true);
            _buttonValue.gameObject.SetActive(false);
        }
    }

    private void ChangeColor(bool active)
    {
        if (active)
        {
            _axisValue.color = _activeColor;
            _buttonValue.color = _activeColor;
            _label.color = _activeColor;
            _barBackground.color = _activeColor;
        }
        else
        {
            _axisValue.color = _inactiveColor;
            _buttonValue.color = _inactiveColor;
            _label.color = _inactiveColor;
            _barBackground.color = _inactiveColor;
        }
    }
}
