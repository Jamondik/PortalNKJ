using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость передвижения
    public float lookSpeed = 2f; // Скорость вращения камеры
    public float jumpForce = 5f; // Сила прыжка

    private Rigidbody rb;
    private Transform playerTransform;

    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerTransform = GetComponent<Transform>();

        // Блокируем курсор
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Получаем вектор скорости
        Vector3 velocity = rb.velocity;

        // Преобразуем вектор скорости в локальную систему координат игрока
        Vector3 localVelocity = playerTransform.InverseTransformDirection(velocity);

        Vector3 worldVelocity = playerTransform.TransformDirection(localVelocity);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        // Движение вперед-назад и влево-вправо
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * moveHorizontal + transform.forward * moveVertical;
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
