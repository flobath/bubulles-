using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectName : MonoBehaviour
{
    protected TMP_Text _text;
    protected float _max_x, _max_y, _min_x, _min_y;

    protected bool _isMain = false;

    private void Awake()
    {
        _max_x = transform.position.x + 10;
        _max_y = transform.position.y + 10;
        _min_x = transform.position.x - 10;
        _min_y = transform.position.y - 10;
        _text = GetComponent<TMP_Text>();
    }

    public void SetText(string pText)
    {
        _text.text = pText;
    }

    public void shuffleText()
    {
        List<char> chars = new List<char>(_text.text.ToCharArray());
        
        int n = chars.Count;  
        while (n > 1) {  
            n--;  
            int k = Random.Range(0, n + 1);
            char value = chars[k];  
            chars[k] = chars[n];  
            chars[n] = value;  
        }
        _text.text = new string(chars.ToArray());
    }

    protected void Update()
    {
        if (_isMain)
        {
            return;
        }
        if (transform.position.x > _max_x)
        {
            transform.position = new Vector3(_min_x, transform.position.y, transform.position.z);
        }
        if (transform.position.x < _min_x)
        {
            transform.position = new Vector3(_max_x, transform.position.y, transform.position.z);
        }
        if (transform.position.y > _max_y)
        {
            transform.position = new Vector3(transform.position.x, _min_y, transform.position.z);
        }
        if (transform.position.y < _min_y)
        {
            transform.position = new Vector3(transform.position.x, _max_y, transform.position.z);
        }
        transform.position = new Vector3(transform.position.x + Random.Range(-1, 1), transform.position.y + Random.Range(-1, 1), transform.position.z);
    }

    public void SetMain(bool pIsMain)
    {
        _isMain = pIsMain;
    }
}
