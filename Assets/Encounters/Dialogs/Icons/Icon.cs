using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Icon.
/// </summary>
/// <seealso cref="MonoBehaviour" />
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
        slotPoint = Vector3.zero;
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
                progress = 1.0f;
                isSnapping = false;
            }
            transform.position = Vector3.Lerp(releasePoint, endPoint, progress);
        }
    }

    /// <summary>
    /// Called when an icon is clicked and sets up the logic for dragging this icon with the mouse and it snapping.
    /// </summary>
    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;
        isSnapping = false;
    }

    /// <summary>
    /// Called when an icon is released and sets up the logic for dragging this icon with the mouse and it snapping.
    /// </summary>
    private void OnMouseUp()
    {
        releasePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // If we have collided with a slot use its position, otherwise go back to the origin.
        endPoint = slotPoint != Vector3.zero ? slotPoint : originPoint;
        isDragging = false;
        isSnapping = true;
        progress = 0.0f;
    }

    // When this collides with another collider.
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Collision is not a slot.
        if (other.gameObject.tag != "Slot")
        {
            return;
        }
        Slot script = other.GetComponent<Slot>();
        // Slot already has an icon.
        if (script.Icon)
        {
            return;
        }
        script.AddGameObject(this.gameObject);
        slotPoint = other.gameObject.transform.position;
    }

    // When this stops colliding with another collider.
    private void OnTriggerExit2D(Collider2D other)
    {
        // Exit is not a slot.
        if (other.gameObject.tag != "Slot")
        {
            return;
        }
        Slot script = other.GetComponent<Slot>();
        // The exit is not the to the slot assigned icon.
        if (script.Icon != this.gameObject)
        {
            return;
        }
        script.RemoveGameObject();
        slotPoint = Vector3.zero;
    }
}
