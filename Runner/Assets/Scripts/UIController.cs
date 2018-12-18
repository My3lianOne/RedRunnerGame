using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Скрипт-оператор интерфейса.
/// </summary>
public class UIController : MonoBehaviour {
    
    /// <summary>
    /// Ссылка на скрипт-оператор игры.
    /// </summary>
	private GameController gc;

    /// <summary>
    /// Ссылка на текст с очками.
    /// </summary>
	[SerializeField]
	private Text scoreText;

    /// <summary>
    /// Ссылка на экземпляр оператора интерфейса.
    /// </summary>
    private static UIController instance;

    /// <summary>
    /// Текст Очки
    /// </summary>
    private const string pointsTxt = "Очки: ";

    void Awake () {
        
        // Реализуем одиночку.
        if (instance == null)
        {
            instance = this;
            gc = FindObjectOfType<GameController>();
            gc.GameOverEvent += OnGameOver;
            gc.GameLoadedEvent += OnGameLoaded;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(gameObject);

		pointer.enabled = false;
	}
	
	void Update () {
        
        // Ловим паузу.
        if (Input.GetButtonUp("Cancel") && gc.State == GameController.GAME_STATE.Started )
        {
            PauseGame();
        }
        else if (Input.GetButtonUp("Cancel") && gc.State == GameController.GAME_STATE.Pause)
        {
            ResumeGame();
        }

        // Обновляем очки.
        scoreText.text = pointsTxt + gc.Points;
	}

	#region Главное меню

    /// <summary>
    /// Ссылка на кнопку Начать.
    /// </summary>
	[SerializeField]
	private Button runBtn;
    
    /// <summary>
    /// Ссылка на кнопку Выйти.
    /// </summary>
	[SerializeField]
    private Button quitBtn;

    /// <summary>
    /// Ссылка на панель главного меню.
    /// </summary>
	[SerializeField]
    private GameObject mainMenuTab;

    /// <summary>
    /// Ссылка на маркер.
    /// </summary>
	[SerializeField]
    private RawImage pointer; 

    /// <summary>
    /// Обработчик наведения курсора на кнопку Начать.
    /// </summary>
	public void RunBtnOnMouseEnter () {
		pointer.enabled = true;
		pointer.transform.position = new Vector2( pointer.transform.position.x, runBtn.transform.position.y);
	}

    /// <summary>
    /// Обработчик ухода курсора с кнопки Начать.
    /// </summary>
    public void RunBtnOnMouseExit () {
		pointer.enabled = false;
	}

    /// <summary>
    /// Обработчик наведения курсора на кнопку Выйти.
    /// </summary>
	public void QuitBtnOnMouseEnter () {
		pointer.enabled = true;
		pointer.transform.position = new Vector2( pointer.transform.position.x, quitBtn.transform.position.y);
	}

    /// <summary>
    /// Обработчик ухода курсора с кнопки Выйти.
    /// </summary>
    public void QuitBtnOnMouseExit () {
		pointer.enabled = false;
	}

	#endregion

	#region  Меню паузы
	
    /// <summary>
    /// Панель меню паузы.
    /// </summary>
	[SerializeField]
	private GameObject gamePauseTab;

    /// <summary>
    /// Ссылка на кнопку Выйти.
    /// </summary>
	[SerializeField]
    private Button quitPauseBtn;

    /// <summary>
    /// Ссылка на кнопку "Продолжить".
    /// </summary>
	[SerializeField]
    private Button resumeBtn;

    /// <summary>
    /// Ссылка на указатель.
    /// </summary>
	[SerializeField]
    private RawImage pauseTabPointer; 

    /// <summary>
    /// Обработчик наведения курсора на кнопку Продолжить.
    /// </summary>
	public void ResumeBtnOnMouseEnter () {
		pauseTabPointer.gameObject.SetActive(true);
		pauseTabPointer.transform.position = new Vector2( pauseTabPointer.transform.position.x, resumeBtn.transform.position.y);
	}

    /// <summary>
    /// Обработчик ухода курсора с кнопки Продолжить.
    /// </summary>
    public void ResumeBtnOnMouseExit () {
		pauseTabPointer.gameObject.SetActive(false);
	}

    /// <summary>
    /// Обработчик наведения курсора на кнопку Выйти.
    /// </summary>
    public void QuitPauseBtnOnMouseEnter () {
		pauseTabPointer.gameObject.SetActive(true);
		pauseTabPointer.transform.position = new Vector2( pauseTabPointer.transform.position.x, quitPauseBtn.transform.position.y);
	}

    /// <summary>
    /// Обработчик ухода курсора с кнопки Выйти.
    /// </summary>
	public void QuitPauseBtnOnMouseExit () {
		pauseTabPointer.gameObject.SetActive(false);
	}
	#endregion
	
	#region Меню Game Over

    /// <summary>
    /// Ссылка на кнопку Заново.
    /// </summary>
	[SerializeField]
    private Button restartBtn;

    /// <summary>
    /// Ссылка на кнопку Выйти.
    /// </summary>
	[SerializeField]
    private Button quitGOBtn;

    /// <summary>
    /// Ссылка на панель меню Game Over.
    /// </summary>
	[SerializeField]
    private GameObject GOTab;

    /// <summary>
    /// Ссылка на указатель.
    /// </summary>
	[SerializeField]
    private RawImage goPointer;

    /// <summary>
    /// Обработчик наведения курсора на кнопку Заново.
    /// </summary>
    public void RestartBtnOnMouseEnter () {
		goPointer.gameObject.SetActive(true);
		goPointer.transform.position = new Vector2( goPointer.transform.position.x, restartBtn.transform.position.y);
	}

    /// <summary>
    /// Обработчик ухода курсора с кнопки Заново.
    /// </summary>
    public void RestartBtnOnMouseExit () {
		goPointer.gameObject.SetActive(false);
	}

    /// <summary>
    /// Обработчик наведения курсора на кнопку Выйти.
    /// </summary>
    public void QuitGOBtnOnMouseEnter () {
		goPointer.gameObject.SetActive(true);
		goPointer.transform.position = new Vector2( goPointer.transform.position.x, quitGOBtn.transform.position.y);
	}

    /// <summary>
    /// Обработчик ухода курсора с кнопки Выйти.
    /// </summary>
    public void QuitGOBtnOnMouseExit () {
		goPointer.gameObject.SetActive(false);
	}

	#endregion


    /// <summary>
    /// Ставит игру на паузу.
    /// </summary>
	public void PauseGame() {
		gamePauseTab.SetActive(true);
        gc.PauseGame();
    }

    /// <summary>
    /// Запускает игру.
    /// </summary>
	public void StartGame() {
		mainMenuTab.SetActive(false);
		gc.StartGame();
	}

    /// <summary>
    /// Перезапускает игру.
    /// </summary>
	public void RestartGame() {
		gc.RestartGame();
        GOTab.SetActive(false);
    }

    /// <summary>
    /// Возобновляет игру.
    /// </summary>
	public void ResumeGame() {
		gamePauseTab.SetActive(false);
        gc.ResumeGame();
	}

    /// <summary>
    /// Выходит из игры.
    /// </summary>
	public void QuitGame() {
		gc.QuitGame();
	}

    /// <summary>
    /// Обработчик события Завершение игры.
    /// </summary>
	public void OnGameOver() {
		if(GOTab)
            GOTab.SetActive(true);
	}

    /// <summary>
    /// Обработчик события загрузки игры.
    /// </summary>
    public void OnGameLoaded()
    {
        mainMenuTab.SetActive(true);
    }
}
