using UnityEngine;
using System.Collections;

/// <summary>
/// Applies a RTS style movement for a camera
/// </summary>
public class CameraController : MonoBehaviour {
    [SerializeField]
    private float moveSpeed = 20.0f;
    [SerializeField]
    private float zoomSpeed = 2000.0f;
    [SerializeField]
    private bool useKeys = false;
    [SerializeField]
    private bool useMouse = true;
    [SerializeField]
    private float mouseBorder = 0.05f;
    [SerializeField]
    private float maxHeight = 40.0f;
    [SerializeField]
    private float minHeight = 10.0f;
    [SerializeField]
    private float frontBoundary = 40.0f;
    [SerializeField]
    private float backBoundary = 40.0f;
    [SerializeField]
    private float leftBoundary = 40.0f;
    [SerializeField]
    private float rightBoundary = 40.0f;

    #region Getter Setter
    public float MoveSpeed { get { return moveSpeed; } set { moveSpeed = value; } }
    public float ZoomSpeed { get { return zoomSpeed; } set { zoomSpeed = value; } }
    public bool UseKeys { get { return useKeys; } set { useKeys = value; } }
    public bool UseMouse { get { return useMouse; } set { useMouse = value; } }
    public float MouseBorder { get { return mouseBorder; } set { mouseBorder = value; } }
    public float MaxHeight { get { return maxHeight; } set { maxHeight = value; } }
    public float MinHeight { get { return minHeight; } set { minHeight = value; } }
    public float FrontBoundary { get { return frontBoundary; } set { frontBoundary = value; } }
    public float BackBoundary { get { return backBoundary; } set { backBoundary = value; } }
    public float LeftBoundary { get { return leftBoundary; } set { leftBoundary = value; } }
    public float RightBoundary { get { return rightBoundary; } set { rightBoundary = value; } }
    #endregion

    void Start() {

    }
	
	void Update () {
        flatMovement();
        zoomMovement();
	}

    private void flatMovement() {
        float screenHeight = Screen.height;
        float areaTopBottomSize = screenHeight * mouseBorder;
        float screenWidth = Screen.width;
        float areaLeftRightSize = screenWidth * mouseBorder;

        if ((useKeys && Input.GetKey(KeyCode.W)) || (useMouse && Input.mousePosition.y > screenHeight - areaTopBottomSize)) {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World);
        }

        if ((useKeys && Input.GetKey(KeyCode.S)) || (useMouse && Input.mousePosition.y < areaTopBottomSize)) {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime, Space.World);
        }

        if ((useKeys && Input.GetKey(KeyCode.A)) || (useMouse && Input.mousePosition.x < areaLeftRightSize)) {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime, Space.World);
        }

        if ((useKeys && Input.GetKey(KeyCode.D)) || (useMouse && Input.mousePosition.x > screenWidth - areaLeftRightSize)) {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime, Space.World);
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -leftBoundary, rightBoundary), transform.position.y, Mathf.Clamp(transform.position.z, -backBoundary, frontBoundary));
    }

    private void zoomMovement() {
        transform.Translate(Vector3.forward * Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, minHeight, maxHeight), transform.position.z);
        moveSpeed = transform.position.y * 5;
        
    }
}
