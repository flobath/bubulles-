using UnityEngine;
using System.Collections.Generic;

public class Objective : MonoBehaviour
{
    private List<string> _objectives;
    [SerializeField] private List<string> _menu;
    [SerializeField] private List<string> _milks;
    [SerializeField] private List<string> _sizes;
    [SerializeField] private GameObject _drink;
    [SerializeField] private GameObject _milk;
    [SerializeField] private GameObject _size;



    public List<string> GetObjectives()
    {
        return _objectives;
    }

    public List<string> GetMenu()
    {
        List<string> menu = new List<string>();
        foreach (string item in _menu)
        {
            menu.Add(item);
        }
        foreach (string item in _milks)
        {
            menu.Add(item);
        }
        foreach (string item in _sizes)
        {
            menu.Add(item);
        }
        return menu;
    }

    protected void Awake()
    {
        _objectives = new List<string>();
        _objectives.Add(_menu[Random.Range(0, _menu.Count - 1)]);
        _objectives.Add(_milks[Random.Range(0, _milks.Count - 1)]);
        _objectives.Add(_sizes[Random.Range(0, _sizes.Count - 1)]);
        _drink.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = _objectives[0];
        _milk.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = _objectives[1];
        _size.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = _objectives[2];
    }
}