using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Скрипт триггеров падения в пропасть.
/// Используется для отслеживания попаданий игрока
/// в пропасть и на шипы.
/// </summary>
public class FallTrigger : MonoBehaviour {
    
    /// <summary>
    /// Ссылка на оператора игры.
    /// </summary>
    private GameController gc;

	void Start () {
        gc = FindObjectOfType<GameController>();
    }
	
    /// <summary>
    /// Обработчик коллизии с триггером.
    /// </summary>
    /// <param name="col"></param>
	void OnTriggerEnter2D (Collider2D col) {
		if (col.transform.tag == "Player") {
			gc.GameOver();
		}
	}
}
