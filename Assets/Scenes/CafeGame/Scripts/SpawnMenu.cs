using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMenu : MonoBehaviour
{
    [SerializeField] private int _width, _height;
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private Vector3 _scale;

    private void Start() {
        GenerateGrid();
    }

    void GenerateGrid() {
        for (int x = 0; x < _width; x++) {
            for (int y = 0; y < _height; y++) {
                var SpawnedTile = Instantiate(_tilePrefab, new Vector3(x, y, 0), Quaternion.identity);
                SpawnedTile.transform.SetParent(transform);
                SpawnedTile.transform.localScale = _scale;
                float pos_x = transform.position.x + (transform.localScale.x / 16) * (x - 2) + (transform.localScale.x / 8) * (x - 2);
                float pos_y = transform.position.y + (transform.localScale.y / 10) * (y - 1) + (transform.localScale.y / 5) * (y - 1);
                SpawnedTile.transform.position = new Vector3(pos_x, pos_y, SpawnedTile.transform.position.z);
            }
        }
    }
}