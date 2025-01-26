using UnityEngine;
using TMPro;

public class AnswerDropdown : MonoBehaviour
{
    public int getSelectedIndex()
    {
        var dropdown = GetComponent<TMPro.TMP_Dropdown>();
        return dropdown.value;
    }
}