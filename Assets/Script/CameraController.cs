using UnityEngine;

public class CameraController : MonoBehaviour {
    public Transform target;

    public float smoothSpeed = 10f;

    public Vector3 offset;

    public int boundary = 50;
    public float speed = 5.0f;

    private int screenWidth;
    private int screenHeight;

    // For debug purpose
    public float debugTime;

    private void Start()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
    }

    void FixedUpdate()
    {
        MouseScrollZoom();
        MouseHitEdgeCameraMove();
    }

    void CameraFollowsPlayer()
    {
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

    // Move camera whenever the mouse hit the boundary of the screen
    void MouseHitEdgeCameraMove()
    {
        if (Input.mousePosition.x > screenWidth - boundary) { transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * speed * Time.deltaTime, 0.0f, 0.0f); }
        if (Input.mousePosition.x < 0 + boundary) { transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * speed * Time.deltaTime, 0.0f, 0.0f); }
        if (Input.mousePosition.y > screenHeight - boundary) { transform.position += new Vector3(0.0f, Input.GetAxisRaw("Mouse Y") * speed * Time.deltaTime, 0.0f); }
        if (Input.mousePosition.y < 0 + boundary) { transform.position += new Vector3(0.0f, Input.GetAxisRaw("Mouse Y") * speed * Time.deltaTime, 0.0f); }
    }
}
