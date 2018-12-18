using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Оператор диалогов.
/// </summary>
public class DialogController : MonoBehaviour {

    /// <summary>
    /// Массив с фразами.
    /// </summary>
    [SerializeField]
    private string[] texts;

    /// <summary>
    /// Ссылка на текстовое поле.
    /// </summary>
    [SerializeField]
    private Text textField;

    /// <summary>
    /// Ссылка на текст-бабл.
    /// </summary>
    [SerializeField]
    private GameObject dialogBubble;

    /// <summary>
    /// Очередь фраз.
    /// </summary>
    private Queue<string> textQueue;

    /// <summary>
    /// Признак завершения диалога.
    /// </summary>
    bool isEnd = false;

    /// <summary>
    /// Ссылка на срипт-оператор игры.
    /// </summary>
    private GameController gc;

    private void Start()
    {
        gc = FindObjectOfType<GameController>();
        textQueue = new Queue<string>();

        // Заполняем очередь фразами.
        foreach (string text in texts)
        {
            textQueue.Enqueue(text);
        }

        StartDialog();
    }

    /// <summary>
    /// Запускает диалог.
    /// </summary>
    public void StartDialog()
    {
        dialogBubble.SetActive(true);
        textField.text = GetText();
    }

    /// <summary>
    /// Получает фразу из очереди.
    /// </summary>
    /// <returns></returns>
    string GetText()
    {
         try
        {
            return textQueue.Dequeue();
        }
        catch (InvalidOperationException)
        {
            isEnd = true;
            return "";
        }
    }


    private void Update()
    {
        // Если диалог завершен.
        if (isEnd)
        {
            dialogBubble.SetActive(false);

            // Костыль ;) Тут должен быть делегат на обработку завершения диалога..
            gc.EndGame();
        }
        
        // Перещелкиваем фразы.
        if (Input.GetButtonDown("Fire1"))
        {
            NextText();
        }
    }

    /// <summary>
    /// Переключает фразу.
    /// </summary>
    void NextText()
    {
        textField.text = GetText();
    }
}
