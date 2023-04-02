using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon : MonoBehaviour
{
    // Positions snapped to.
    private Vector3 originPoint;
    private Vector3 slotPoint;

    // Drag logic.
    private bool isDragging;
    private Vector3 offset;

    // Snap logic.
    private bool isSnapping;
    private float progress;
    private Vector3 releasePoint;
    private Vector3 endPoint;

    // Start is called before the first frame update
    void Start()
    {
        Canvas.ForceUpdateCanvases();
        originPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            return;
        }
        if (isSnapping)
        {
            progress += 3.0f * Time.deltaTime;
            if (progress >= 1.0f)
            {
                progress = Math.Clamp(progress, 0.0f, 1.0f);
                isSnapping = false;
            }
            transform.position = Vector3.Lerp(releasePoint, endPoint, progress);
        }
    }

    // Called when the mouse is clicked on a gameobject with this script
    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;
        isSnapping = false;
    }

    // Called when the mouse is released on a gameobject with this script
    private void OnMouseUp()
    {
        releasePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        endPoint = slotPoint == null ? slotPoint : originPoint;
        isDragging = false;
        isSnapping = true;
        progress = 0.0f;
    }

    // TODO: Collision with slot set slotPosition
}
