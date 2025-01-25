using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class NextButton : MonoBehaviour
{
    [SerializeField] private SpawnMenu _spawnMenu;
    [SerializeField] private List<string> _buttonName;
    [SerializeField] private GameObject _text;

    protected void Start()
    {
        nextButton();
    }

    public void nextButton()
    {
        if (_buttonName.Count == 0)
        {
            return;
        }
        TMP_Text text = _text.GetComponent<TMP_Text>();
        text.text = _buttonName[0];
        _buttonName.RemoveAt(0);
        _spawnMenu.GenerateGrid();

    }
}