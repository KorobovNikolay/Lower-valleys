using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Persone", menuName = "Data/Player/Persone")]
public class Persone : Player
{
    private List<SelectMap> _listSelected = new List<SelectMap>();
    private int _indexObject = 0;
    private Tile _currentTile = null;

    public override bool Move()
    {
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonUp(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Tile"))
                {
                    ClearSelected();

                    var tile = hit.transform.GetComponent<Tile>();
                    var actors = tile.GetComponentsInChildren<Actor>();

                    if (_currentTile == tile)
                    {
                        _indexObject++;
                        if (_indexObject > actors.Length - 1)
                            _indexObject = 0;
                    }
                    else
                    {
                        _indexObject = 0;
                        _currentTile = tile;
                    }


                    if (actors.Length.Equals(0))
                        _listSelected.Add(_currentTile.Select(_map.PrefabSelect.ColorSelectTile));

                    else
                        _listSelected.AddRange(actors[_indexObject].Select());
                }
            }
        }

        return false;
    }

    private void ClearSelected()
    {
        _listSelected.ForEach(select => Destroy(select.gameObject));
        _listSelected.Clear();
    }
}
