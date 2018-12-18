using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Оператор орла.
/// </summary>
public class Eagle : MonoBehaviour {
    
    /// <summary>
    /// Скорость передвижения.
    /// </summary>
    [SerializeField]
    private float moveSpd;

    /// <summary>
    /// Время жизни.
    /// </summary>
    [SerializeField]
    private float lifeTime;

    /// <summary>
    /// Активатор
    /// </summary>
    [SerializeField]
    private Trigger trigger;

    /// <summary>
    ///  Признак "активен".
    /// </summary>
    bool isActive = false;

    void Awake () {
        
        // Подписываемся на активацию триггера.
        trigger.TriggerOn += OnTrigger;
    }

	// Update is called once per frame
	void Update () {
        if (isActive)
        {
            
            // Перемещаем.
            transform.position += Vector3.left * moveSpd * Time.deltaTime;

            // Уменьшаем время жизни.
            lifeTime -= Time.deltaTime;

            // Время жизни истекло - уничтожаем.
            if (lifeTime <= 0)
                Destroy(gameObject.transform.parent.gameObject);
        }

    }

    /// <summary>
    /// Обработчик события активации.
    /// </summary>
    public void OnTrigger()
    {
        isActive = true;
    }
}
