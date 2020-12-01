using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Persone", menuName = "Data/Player/Persone")]
public class Persone : Player
{
    private Champion _curentChampion = null;
    private Tile _currentTile = null;
    private List<SelectMap> _listSelected = new List<SelectMap>();
    
    public override void Create(Map map)
    {
        base.Create(map);

        _cameraMove.LookAtTile(Builds.Find(b => b is Castle).Tile);
        _currentTile = Builds[0].Tile;
    }

    public override void Refresh()
    {
        base.Refresh();
        ClearSelected();
    }

    public override void Move()
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
                    var champion = tile.GetComponentInChildren<Champion>();


                    // Если выбран пустой тайл
                    if (champion is null)
                        _listSelected.Add(tile.Select(_map.PrefabSelect.ColorSelectTile));
                    
                    // Если выбран чемпион
                    else
                    {
                        if (champion.Player.Equals(this))
                        {
                            // Установить активного чемпиона
                            _curentChampion = champion;
                            _listSelected.AddRange(champion.Select());
                        }
                    }

                    // Если выбран чепион и сделан ход
                    if (_curentChampion != null && _currentTile != tile)
                    {
                        _curentChampion.Move(tile);
                    }

                    _currentTile = tile;
                }
            }
        }
    }

    public void ClearSelected()
    {
        _listSelected.ForEach(select => Destroy(select.gameObject));
        _listSelected.Clear();
    }
}
