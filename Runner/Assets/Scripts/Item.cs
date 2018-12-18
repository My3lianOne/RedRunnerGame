using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Оператор собираемого предмета
/// </summary>
public class Item : MonoBehaviour {

    /// <summary>
    /// Стоимость предмета.
    /// </summary>
    [SerializeField]
    private int cost;

    public int Cost
    {
        get
        {
            return cost;
        }
    }

    /// <summary>
    /// Ссылка на аниматор.
    /// </summary>
    private Animator anim;


	void Start() {
		anim = GetComponent<Animator>();
	}

    /// <summary>
    /// Обработка коллизии с персонажем.
    /// </summary>
    /// <param name="col">Коллайдер</param>
	void OnTriggerEnter2D (Collider2D col) {
		if (col.transform.tag == "Player"){
			Pick();
			anim.SetTrigger("Picked");
			GetComponent<AudioSource>().Play();
		}
	}

    /// <summary>
    /// Удаляет объект (вызывается из анимации).
    /// </summary>
	public void DestroyItem () {
		Destroy(this.gameObject);
	}

    /// <summary>
    /// Подбирает предмет.
    /// </summary>
    public void Pick()
    {
        FindObjectOfType<GameController>().GetComponent<GameController>().PointsUp(Cost);
    }
}
