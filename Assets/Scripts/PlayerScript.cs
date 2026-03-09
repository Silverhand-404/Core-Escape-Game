using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private float moveSpeed = 3.5f;
    private float jumpForce = 7f;
    private float coliderDistance = 0.05f;

    private bool jumpPressed;
    private float hInput;

    private Rigidbody2D _rb;
    private BoxCollider2D _col;
    public LayerMask groundLayerMask;

    // Флаг - держит ли игрок ядро
    public bool hasCore = false;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _col = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        // Получаем горизонтальный ввод
        hInput = Input.GetAxis("Horizontal");
        // Проверка прыжка
        if ((Input.GetKeyDown(KeyCode.Space)))
            jumpPressed = true;
    }

    void FixedUpdate()
    {

        // Прыжок
        if (IsGrounded() && jumpPressed)
        {
            _rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpPressed = false;
        }
        // Горизонтальное движение
        _rb.linearVelocity = new Vector2(hInput * moveSpeed, _rb.linearVelocity.y);

    }
    //Проверка контакта с землей (для прыжка)
    private bool IsGrounded()
    {
        Vector2 boxBottom = new Vector2(_col.bounds.center.x, _col.bounds.min.y - coliderDistance);
        Vector2 boxColiderSize = new Vector2(_col.size.x*0.7f, 0.1f);
        bool grounded = Physics2D.OverlapBox(boxBottom, boxColiderSize, 0f, groundLayerMask);
        return grounded;
    }
}