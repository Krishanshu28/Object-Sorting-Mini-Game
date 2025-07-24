using UnityEngine;

public class DraggableObject : MonoBehaviour {
    private Vector3 offset;
    private bool isDragging = false;
    private Camera cam;
    private Rigidbody rb;
    private float zCoord;
    private bool alreadyHandled = false;
    void Start() {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    void OnMouseDown() {
        isDragging = true;

        // Get current z-distance to camera
        zCoord = cam.WorldToScreenPoint(transform.position).z;

        offset = transform.position - GetMouseWorldPosition();

        // Disable gravity
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 mouseWorldPos = GetMouseWorldPosition();
            transform.position = mouseWorldPos + offset;
        }
    }

    void OnMouseUp() {
        isDragging = false;
        rb.useGravity = true;
        rb.velocity = Vector3.down * 1.5f;

        // Raycast to detect bin
        // Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        // if (Physics.Raycast(ray, out RaycastHit hit)) {
        //     Bin bin = hit.collider.GetComponent<Bin>();
        //     if (bin != null) {
        //         bin.CheckObject(this.gameObject);
        //     }print(hit.collider.name);
        // }
    }
    void OnTriggerEnter(Collider other)
    {
        if (alreadyHandled) return;

        alreadyHandled = true;

        Bin bin = other.GetComponent<Bin>();
        if (bin != null)
        {
            bin.CheckObject(this.gameObject);
            return;
        }

        // If hit ground directly
        if (other.CompareTag("Finish"))
        {
            GameManager.Instance.LoseLife();
            gameObject.SetActive(false);
        }
    }

    Vector3 GetMouseWorldPosition() {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCoord;
        return cam.ScreenToWorldPoint(mousePoint);
    }
}
