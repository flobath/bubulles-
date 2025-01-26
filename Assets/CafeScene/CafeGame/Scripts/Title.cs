using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Title : MonoBehaviour
{
    [SerializeField] private List<Sprite> _images;

    public void nextImage()
    {
        if (_images.Count == 0)
        {
            gameObject.SetActive(false);
            return;
        }
        var image = GetComponent<Image>();
        image.sprite = _images[0];
        _images.RemoveAt(0);
    }
}