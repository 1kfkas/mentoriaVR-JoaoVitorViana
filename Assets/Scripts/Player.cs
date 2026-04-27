using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float moveSpeed = 0.1f;
    public float mouseSensitivity = 0.01f;
    
    private Rigidbody rb;
    private Vector2 moveInput;
    private Camera playerCamera;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Controle de Câmera
        float mouseX = Mouse.current.delta.x.ReadValue();
        float mouseY = Mouse.current.delta.y.ReadValue();
        
        transform.Rotate(Vector3.up * mouseX * mouseSensitivity);
        playerCamera.transform.localRotation *= Quaternion.Euler(-mouseY * mouseSensitivity, 0, 0);
        playerCamera.transform.localRotation = Quaternion.Euler(Mathf.Clamp(playerCamera.transform.localRotation.x, 80f, -80f), 0, 0);
    }

    void FixedUpdate()
    {
        // Movimentação baseada em Input
        float moveX = Keyboard.current.aKey.isPressed ? -1f : Keyboard.current.dKey.isPressed ? 1f : 0f;
        float moveZ = Keyboard.current.wKey.isPressed ? 1f : Keyboard.current.sKey.isPressed ? -1f : 0f;

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);
    }
}   