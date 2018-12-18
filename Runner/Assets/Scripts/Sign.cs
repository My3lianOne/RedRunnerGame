using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Чекпоинт.
/// </summary>
public class Sign : MonoBehaviour {

    /// <summary>
    /// Ссылка на скрипт-оператор.
    /// </summary>
    [SerializeField]
    private GameController gc;

    /// <summary>
    /// Ссылка на объект-точку респавна.
    /// </summary>
    [SerializeField]
    private GameObject point;

    void Start()
    {
        gc = FindObjectOfType<GameController>();  
    }

    void OnTriggerEnter2D(Collider2D col) {
        
        // Активируем чекпоинт, если персонаж прошел мимо.
		if (col.tag == "Player") {
			GetComponent<Animator>().SetTrigger("Activate");
            gc.ActivateCheckPoint(point);
		}
	}
}
