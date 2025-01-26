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
    [SerializeField] private List<AnswerDropdown> _dropdowns;
    [SerializeField] private Title _title;
    protected int _step = 4;

    protected void Start()
    {
        nextButton();
    }

    public void nextButton()
    {
        if (_step == 0)
        {
            checkWin();
            return;
        }
        if (_step == 1)
        {
            _spawnMenu.SetActive(false);
            _takeOrder.SetActive(true);
        }
        _spawnMenu.GenerateGrid();
        _title.nextImage();
        _step--;
    }

    public void checkWin()
    {
        int coffee = _dropdowns[0].getSelectedIndex();
        int milk = _dropdowns[1].getSelectedIndex();
        int size = _dropdowns[2].getSelectedIndex();

        if (coffee == _spawnMenu.GetGoodAnswer()[0] && milk == _spawnMenu.GetGoodAnswer()[1] && size == _spawnMenu.GetGoodAnswer()[2])
        {
            Debug.Log("You win!");
        }
        else
        {
            Debug.Log("You lose!");
        }
    }
}