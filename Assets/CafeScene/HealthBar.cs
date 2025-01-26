using System.Runtime.CompilerServices;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public GameObject player;
    private Player player_script;

    private RectTransform _transform;

    private void Start()
    {
        player_script = player.GetComponent<Player>();
        _transform = GetComponent<RectTransform>();
    }

    void Update()
    {
        float healthBarSize = Mathf.Clamp(player_script.anxiety, 0, 95.75f);;
    
        _transform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, healthBarSize);
    }
}
