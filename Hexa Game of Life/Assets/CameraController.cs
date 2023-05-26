using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float zoomSpeed = 10f;
    public float moveSpeed = 10f;
    public bool isDragging=false;

    public Vector2 minPosition;
    public Vector2 maxPosition;

    private Camera cam;
    private Vector3 dragOrigin;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        // Zooming
        float scrollDelta = Input.mouseScrollDelta.y;
        Zoom(scrollDelta);

        // Moving
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            isDragging = true;
        }
        if (Input.GetMouseButtonUp(0)) {
        isDragging = false;
        }

        if (isDragging)
        {
            Vector3 dragDelta =  Input.mousePosition -dragOrigin;
            MoveCamera(dragDelta);
        }
    }

    private void Zoom(float delta)
    {
        float zoomAmount = delta * zoomSpeed ;
        cam.orthographicSize -= zoomAmount;
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, 1f, Mathf.Infinity);
    }

    private void MoveCamera(Vector3 delta)
    {
        Vector3 moveAmount = delta * moveSpeed * Time.deltaTime;
        Vector3 newPosition = transform.position - moveAmount;
        newPosition.x = Mathf.Clamp(newPosition.x, minPosition.x, maxPosition.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minPosition.y, maxPosition.y);
        transform.position = newPosition;
    }
}
