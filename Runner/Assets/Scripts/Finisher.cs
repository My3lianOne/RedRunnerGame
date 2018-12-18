using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Скрипт завершения игры по достижению цели.
/// </summary>
public class Finisher : MonoBehaviour {

    /// <summary>
    /// Ссылка на тригер финишера.
    /// </summary>
    [SerializeField]
    private Trigger trigger;

    private DialogController dc;
    private GameController gc;

    private void Awake()
    {
        gc = FindObjectOfType<GameController>();
        dc = GetComponent<DialogController>();
        trigger.TriggerOn += OnTrigger;
    }

    private void OnTrigger()
    {
        // Останавливаем персонажа.
        gc.StopPlayer();

        // Включаем диалог.
        dc.enabled = true;
    }
}
