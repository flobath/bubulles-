using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnMenu : MonoBehaviour
{
    [SerializeField] private List<int> _width, _height;
    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private List<string> _tileNames;
    protected List<GameObject> _tiles = new List<GameObject>();

    public void GenerateGrid() {
        foreach (var tile in _tiles) {
            Destroy(tile);
        }
        int width = _width[0];
        int height = _height[0];
        _width.RemoveAt(0);
        _height.RemoveAt(0);
        float half_width = (float)width / 2;
        float half_height = (float)height / 2;
        int tileCount = width * height;
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                var SpawnedTile = Instantiate(_tilePrefab, new Vector3(x, y, 0), Quaternion.identity);
                string tileName = _tileNames[Random.Range(0, tileCount - 1)];
                SpawnedTile.transform.SetParent(transform);
                RectTransform rt = SpawnedTile.GetComponent (typeof (RectTransform)) as RectTransform;
                float pos_x = transform.position.x + (rt.rect.width * (x - half_width) * SpawnedTile.transform.localScale.x) + (rt.rect.width / 2 * ((x - half_width) + 1.5f) * SpawnedTile.transform.localScale.x); //
                float pos_y = transform.position.y + (rt.rect.height * (y - half_height) * SpawnedTile.transform.localScale.y) + (rt.rect.height / 2 * (y - half_height + 1.5f) * SpawnedTile.transform.localScale.y); //
                SpawnedTile.transform.position = new Vector3(pos_x, pos_y, SpawnedTile.transform.position.z);
                SpawnedTile.SetText(tileName);
                SpawnedTile.SetNumber((height - (y + 1)) * width + x + 1);
                _tileNames.Remove(tileName);
                tileCount--;
                _tiles.Add(SpawnedTile.gameObject);
            }
        }
    }
}