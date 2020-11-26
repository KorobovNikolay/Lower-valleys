using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Persone", menuName = "Data/Player/Persone")]
public class Persone : Player
{
    private List<GameObject> _listSelected = new List<GameObject>();

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
                    _listSelected.Add(hit.transform.GetComponent<Tile>().Select(_map.ColorSelectTile));
                }
            }
        }

        return false;
    }

    private void ClearSelected()
    {
        _listSelected.ForEach(select => Destroy(select));
        _listSelected.Clear();
    }
}
