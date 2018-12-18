using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Оператор рычага.
/// </summary>
public class Crank : MonoBehaviour {

    /// <summary>
    /// Ссылка на спрайт активированного рычага (чтобы не писать аниматор).
    /// </summary>
    [SerializeField]
	private Sprite activeModeSprite;

    /// <summary>
    /// Делегат событий рычага.
    /// </summary>
	public delegate void CrankController();

    /// <summary>
    /// Событие активации.
    /// </summary>
	public event CrankController CrankOn;

	void OnTriggerEnter2D (Collider2D col) {
        
        // Активируем только персонажем.
		if(col.gameObject.tag == "Player") {
			GetComponent<SpriteRenderer>().sprite = activeModeSprite;
			CrankOn();
		}
		
	}
}
