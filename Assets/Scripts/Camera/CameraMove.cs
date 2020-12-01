using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float Speed;

    private Camera _camera;
    private Map _map;

    private bool IsDragging;
    private Vector3 _startPosition;
    private Vector3 _targetPosition;

    private float _fixedBottom, _fixedTop, _fixedLeft, _fixedRight;


    public void LookAtTile(Tile tile)
    {
        if (tile == null)
            throw new NullReferenceException("параметр tile не должен быть null");

        transform.position = new Vector3(tile.transform.position.x, transform.position.y, tile.transform.position.z);
    }

    private void Start()
    {
        _camera = FindObjectOfType<Camera>();
        _map = FindObjectOfType<Map>();

        _targetPosition = transform.position;

        _fixedRight = (_map.Data.Width - 1) * _map.Data.TileWidth;
        _fixedLeft = 0f;
        _fixedBottom = (_map.Data.Height) * _map.Data.TileOffsetPosition;
        _fixedTop = 0f;

    }

    private void Update()
    {
        if (Input.touchCount == 1)
        {

            if (Input.GetMouseButtonDown(0))
            {
                _startPosition = GetWorldPoint(Input.mousePosition);
                IsDragging = true;
            }


            if (IsDragging)
            {
                if (Input.GetMouseButton(0))
                {
                    var position = GetWorldPoint(Input.mousePosition) - _startPosition;

                    _targetPosition =
                        new Vector3(
                            Mathf.Clamp(transform.position.x - position.x, _fixedLeft, _fixedRight),
                            transform.position.y,
                            Mathf.Clamp(transform.position.z - position.y, _fixedTop, _fixedBottom));

                }
            }

            if (Input.GetMouseButtonUp(0)) IsDragging = false;
        }

        else if (Input.touchCount > 1) IsDragging = false;

        var newPosition = new Vector3(Mathf.Lerp(transform.position.x, _targetPosition.x, Speed * Time.deltaTime),
                                         transform.position.y,
                                         Mathf.Lerp(transform.position.z, _targetPosition.z, Speed * Time.deltaTime));


        transform.position = newPosition; ;
    }

    private Vector3 GetWorldPoint(Vector3 mousePosition)
    {
        var point = Vector3.zero;
        var ray = _camera.ScreenPointToRay(mousePosition);
        var normal = Vector3.forward;
        var position = Vector3.zero;
        var plane = new Plane(normal, position);
        float distance;

        plane.Raycast(ray, out distance);
        point = ray.GetPoint(distance);
        return point;
    }

}
