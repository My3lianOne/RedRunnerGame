using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Скрипт-оператор игрока.
/// Используется шаблон "одиночка".
/// </summary>
public class PlayerController : MonoBehaviour {

    /// <summary>
    /// Ссылка на экземпляр игрока.
    /// </summary>
    private static PlayerController instance;

    /// <summary>
    /// Скорость передвижения.
    /// </summary>
    [SerializeField]
    float moveSpd;

    /// <summary>
    /// Сила прыжка.
    /// </summary>
    [SerializeField]
    float jumpForce;

    /// <summary>
    /// Ссылка на объект-детектор соприкосновения с землей.
    /// </summary>
    [SerializeField]
    GameObject groundCheck;

    /// <summary>
    /// Признак "на земле".
    /// </summary>
    bool isGrounded;

    public bool IsGrounded
    {
        get { return isGrounded; }
    }

    /// <summary>
    /// Ссылка на аниматор.
    /// </summary>
    private Animator anim;

    /// <summary>
    /// Может ли персонаж передвигаться.
    /// </summary>
    private bool canMove;

    /// <summary>
    /// Ссылка на скрипт-оператор игры.
    /// </summary>
    [SerializeField]
    private GameController gc;

    /// <summary>
    /// Ссылка на RigidBody.
    /// </summary>
    private Rigidbody2D rb;

    void Awake () {

        // Реализуем одиночку.
        if (instance == null)
        {
            instance = this;
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(gameObject);
   
        canMove = false;
    }

    void LateUpdate () {

        // Проверяем возможность передвижения.
        if(canMove) {

            // Используем простое передвижение.
            transform.position += Vector3.right*moveSpd*Time.deltaTime;

            // Прыжок. Возможно только если персонаж стоит на земле.
            if (Input.GetButtonDown("Fire1") && IsGrounded) {
                Jump();
            }
        }
    }

    void Update()
    {
        // Проверяем стоит ли персонаж на земле.
        isGrounded = Physics2D.Linecast(transform.position, groundCheck.transform.position, 1 << LayerMask.NameToLayer("ground"));

        anim.SetBool("IsGrounded", IsGrounded);
    }
    
    /// <summary>
    /// Устанавливает может ли персонаж передвигаться.
    /// </summary>
    /// <param name="value">Значение.</param>
    public void SetCanMove(bool value)
    {
        canMove = value;
        anim.SetBool("CanMove", canMove);
    }

    /// <summary>
    /// Совершает прыжок.
    /// </summary>
    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce);
        anim.SetTrigger("Jump");
        GetComponent<AudioSource>().Play();
    }
}
