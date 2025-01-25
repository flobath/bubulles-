using UnityEngine;

public class Number : MonoBehaviour
{
    private TMPro.TextMeshProUGUI _text;
    
    public void SetText(string pText)
    {
        _text.text = pText;
    }

    protected void Awake()
    {
        _text = GetComponent<TMPro.TextMeshProUGUI>();
    }
}