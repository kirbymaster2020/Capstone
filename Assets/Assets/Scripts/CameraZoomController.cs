using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoomController : MonoBehaviour
{
    // Reference to your virtual camera
    public CinemachineVirtualCamera virtualCamera;

    // Zoom settings
    public float defaultZoom = 14.7f;   // Default orthographic size (matches your current setting)
    public float minZoom = 5.0f;        // Minimum zoom level (most zoomed in)
    public float maxZoom = 25.0f;       // Maximum zoom level (most zoomed out)
    public float zoomSpeed = 10.0f;     // How fast the zoom changes when holding the button

    // Current target zoom level
    private float currentZoom;

    void Start()
    {
        // If no camera is assigned, try to find it
        if (virtualCamera == null)
        {
            virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
            if (virtualCamera == null)
            {
                Debug.LogError("No CinemachineVirtualCamera found in the scene!");
                enabled = false;
                return;
            }
        }

        // Initialize with default zoom
        currentZoom = defaultZoom;
        virtualCamera.m_Lens.OrthographicSize = currentZoom;
    }

    void Update()
    {
        // Store the current zoom to check if it changed
        float previousZoom = currentZoom;

        // Zoom in while Z is held down (decreases orthographic size)
        if (Input.GetKey(KeyCode.Q))
        {
            currentZoom -= zoomSpeed * Time.deltaTime;
            // Clamp the zoom to prevent going too far in
            currentZoom = Mathf.Max(currentZoom, minZoom);
        }

        // Zoom out while X is held down (increases orthographic size)
        if (Input.GetKey(KeyCode.E))
        {
            currentZoom += zoomSpeed * Time.deltaTime;
            // Clamp the zoom to prevent going too far out
            currentZoom = Mathf.Min(currentZoom, maxZoom);
        }

        // Reset to default zoom when C is pressed
        if (Input.GetKeyDown(KeyCode.C))
        {
            currentZoom = defaultZoom;
        }

        // Only update the camera if the zoom changed
        if (currentZoom != previousZoom)
        {
            virtualCamera.m_Lens.OrthographicSize = currentZoom;
            Debug.Log("Current zoom: " + currentZoom);
        }
    }
}