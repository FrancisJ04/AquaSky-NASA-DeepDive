using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    public float moveSpeed = 3f;

    [Header("C�mara")]
    public float mouseSensitivity = 150f;
    public Transform cameraTransform;

    private float xRotation = 0f;

    void Start()
    {
        // Bloquear el cursor al iniciar
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Move();
        Look();
        HandleCursor();
    }

    void Move()
    {
        // Movimiento b�sico (WASD)
        float horizontal = Input.GetAxis("Horizontal"); // A-D
        float vertical = Input.GetAxis("Vertical");     // W-S

        Vector3 move = (transform.right * horizontal + transform.forward * vertical)
                       * moveSpeed * Time.deltaTime;

        // Aplicar movimiento
        transform.position += move*2;

        // Movimiento vertical (subir/bajar)
        float up = 0f;
        if (Input.GetKey(KeyCode.Space)) up = 1f;           // subir
        if (Input.GetKey(KeyCode.LeftShift)) up = -1f;    // bajar

        transform.position += Vector3.up * up * (moveSpeed * 1.5f) * Time.deltaTime;
    }

    void Look()
    {
        // Movimiento del rat�n
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotaci�n vertical (mirar arriba/abajo)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // limitar el giro vertical

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotaci�n horizontal (mirar izquierda/derecha)
        transform.Rotate(Vector3.up * mouseX);
    }

    void HandleCursor()
    {
        // Liberar cursor con ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        // Volver a bloquearlo con clic
        if (Input.GetMouseButtonDown(0) && Cursor.lockState == CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
