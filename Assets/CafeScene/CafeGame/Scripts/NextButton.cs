using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class NextButton : MonoBehaviour
{
    [SerializeField] private SpawnMenu _spawnMenu;
    [SerializeField] private GameObject _takeOrder;
    [SerializeField] private Title _title;
    [SerializeField] private Title _background;
    protected int _step = 4;

    protected void Start()
    {
        nextButton();
        _background.nextImage();
    }

    public void nextButton()
    {
        _spawnMenu.GenerateGrid();
        _title.nextImage();
        if (_step == 1)
        {
            _spawnMenu.SetActive(false);
            _takeOrder.SetActive(true);
            _background.nextImage();
            gameObject.SetActive(false);
        }
        _step--;
    }

}