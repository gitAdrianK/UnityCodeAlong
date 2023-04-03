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
    private float size;

    // Start is called before the first frame update
    void Start()
    {
        Canvas.ForceUpdateCanvases();
        originPoint = transform.position;
        slotPoint = Vector3.zero;
        size = GetComponent<Renderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        // Unitys mouse up and down is scuffed so we have to check ourselves
        if (Input.GetMouseButtonDown(0) && Vector3.Distance(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition)) <= size / 2)
        {
            MouseDown();
        }
        if (Input.GetMouseButtonUp(0) && Vector3.Distance(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition)) <= size / 2)
        {
            MouseUp();
        }
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

    private void MouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;
        isSnapping = false;
    }

    private void MouseUp()
    {
        releasePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // If we have collided with a slot use its position, otherwise go back to the origin.
        endPoint = slotPoint != Vector3.zero ? slotPoint : originPoint;
        isDragging = false;
        isSnapping = true;
        progress = 0.0f;
    }

    // // Called when the mouse is clicked on a gameobject with this script
    // private void OnMouseDown()
    // {
    //     offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //     isDragging = true;
    //     isSnapping = false;
    // }

    // // Called when the mouse is released on a gameobject with this script
    // private void OnMouseUp()
    // {
    //     releasePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //     // If we have collided with a slot use its position, otherwise go back to the origin.
    //     endPoint = slotPoint != Vector3.zero ? slotPoint : originPoint;
    //     isDragging = false;
    //     isSnapping = true;
    //     progress = 0.0f;
    // }

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
        script.Icon = this.gameObject;
        slotPoint = other.gameObject.transform.position;
    }

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
        script.Icon = null;
        slotPoint = Vector3.zero;
    }
}
