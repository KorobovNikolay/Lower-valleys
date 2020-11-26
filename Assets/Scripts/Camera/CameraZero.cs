using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZero : MonoBehaviour
{
    public float ZoomMin;
    public float ZoomMax;

    private Camera _camera;

    private void Start()
    {
        _camera = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        if (Input.touchCount == 2)
        {
            var touch1 = Input.GetTouch(0);
            var touch2 = Input.GetTouch(1);

            var touchPosition1 = touch1.position - touch1.deltaPosition;
            var touchPosition2 = touch2.position - touch2.deltaPosition;
            var distance = (touchPosition1 - touchPosition2).magnitude;
            var currentDistance = (touch1.position - touch2.position).magnitude;
            var diffirence = currentDistance - distance;

            SetZoom(diffirence * 0.01f);
        }
    }

    private void SetZoom(float increment)
    {
        _camera.orthographicSize = Mathf.Clamp(_camera.orthographicSize - increment, ZoomMin, ZoomMax);
    }
}
