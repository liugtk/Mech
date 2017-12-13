using UnityEngine;

public class CameraController : MonoBehaviour {
    public Transform target;

    public float smoothSpeed = 10f;
    public Vector3 offset;

    // For debug purpose
    public float debugTime;

    void FixedUpdate()
    {
        MouseScrollZoom();

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
        debugTime = Time.deltaTime;
    }

    // Zoom in or out by scolling the mouse
    void MouseScrollZoom()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0) { Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize + 1, 1); }
        if (Input.GetAxis("Mouse ScrollWheel") < 0) { Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize - 1, 1); }
    }
}
