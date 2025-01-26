using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ConfirmOrder : MonoBehaviour
{
    [SerializeField] private List<AnswerDropdown> _dropdowns;
    [SerializeField] private SpawnMenu _spawnMenu;
    [SerializeField] private string _nextSceneName;
    
    public void checkWin()
    {
        int coffee = _dropdowns[0].getSelectedIndex();
        int milk = _dropdowns[1].getSelectedIndex();
        int size = _dropdowns[2].getSelectedIndex();

        if (coffee == _spawnMenu.GetGoodAnswer()[0] && milk == _spawnMenu.GetGoodAnswer()[1] && size == _spawnMenu.GetGoodAnswer()[2])
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(_nextSceneName);
        }
        else
        {
            Debug.Log("You lose!");
        }
    }
}