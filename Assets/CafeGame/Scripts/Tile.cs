using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private ObjectName _name;
    [SerializeField] private Number _number;
    [SerializeField] private float _fadingSpeed;
    protected List<ObjectName> _names = new List<ObjectName>();
    protected bool _isMouseOver = false;
    protected int _num = 0;

    protected void Start()
    {
        _name.SetMain(true);
        for (int i =0; i < 16; i++)
        {
            var duplicate = Instantiate(_name, transform);
            switch (i % 4)
            {
                case 0:
                    duplicate.transform.position = new Vector3(_name.transform.position.x + 10, _name.transform.position.y, _name.transform.position.z);
                    break;
                case 1:
                    duplicate.transform.position = new Vector3(_name.transform.position.x - 10, _name.transform.position.y, _name.transform.position.z);
                    break;
                case 2:
                    duplicate.transform.position = new Vector3(_name.transform.position.x, _name.transform.position.y + 10, _name.transform.position.z);
                    break;
                case 3:
                    duplicate.transform.position = new Vector3(_name.transform.position.x, _name.transform.position.y - 10, _name.transform.position.z);
                    break;
            }
            duplicate.shuffleText();
            _names.Add(duplicate);
        }
    }

    protected void Update()
    {
        if (!_isMouseOver)
        {
            return;
        }
        for (int i = 0; i <= _num; i++)
        {
            var color = _names[i].GetComponent<TMPro.TextMeshProUGUI>().color;
            if (color.a <= 0)
            {
                continue;
            }
            color.a -= Time.deltaTime * _fadingSpeed;
            _names[i].GetComponent<TMPro.TextMeshProUGUI>().color = color;
            if (i == _num && color.a <= 0.5 && _num < 15)
            {
                _num++;
            }
            if (_num > 15 && color.a <= 0 )
            {
                _isMouseOver = false;
            }
        }

    }

    public void SetText(string text)
    {
        _name.SetText(text);
    }
    public void SetNumber(int num)
    {
        string text = num.ToString();
        _number.SetText(text);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        _isMouseOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _isMouseOver = false;
        _num = 0;
        foreach (var name in _names)
        {
            var color = name.GetComponent<TMPro.TextMeshProUGUI>().color;
            color.a = 1;
            name.GetComponent<TMPro.TextMeshProUGUI>().color = color;
        }
    }
}