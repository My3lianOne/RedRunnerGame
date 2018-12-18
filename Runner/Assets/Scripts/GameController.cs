using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Оператор игры.
/// </summary>
public class GameController : MonoBehaviour {
   
    /// <summary>
    /// Ссылка на игрока.
    /// </summary>
    [SerializeField] private PlayerController player;

    /// <summary>
    /// Ссылка на фэйдер.
    /// </summary>
    [SerializeField] private GameObject fader;

    /// <summary>
    /// Ссылка на чекпоинт.
    /// </summary>
    private GameObject checkPoint;

    /// <summary>
    /// Состояния игры.
    /// </summary>
    public enum GAME_STATE
    {
        Started,
        Pause,
        Over,
        Loaded
    }

    /// <summary>
    /// Состояние игры.
    /// </summary>
    public GAME_STATE State { get; set; }

    /// <summary>
    /// Ссылка на экземпляр Гейм-контроллера.
    /// </summary>
    public static GameController instance;

    /// <summary>
    /// Делегат состояний.
    /// </summary>
    public delegate void GameStateController();

    /// <summary>
    /// Событие при первой загрузке игры.
    /// </summary>
	public event GameStateController GameLoadedEvent;

    /// <summary>
    /// Событие при проигрыше.
    /// </summary>
    public event GameStateController GameOverEvent;


    /// <summary>
    /// Очки.
    /// </summary>
    int points;

    public int Points
    {
        get { return points; }
    }

    void Awake()
    {
        // Реализуем одиночку.
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(gameObject);

    }

    void Start () {
        player = FindObjectOfType<PlayerController>();

        GameLoadedEvent();
	}
	
    /// <summary>
    /// Увеличивает очки.
    /// </summary>
    /// <param name="points">Количество очков</param>
	public void PointsUp (int points) {
		this.points += points; 
	}

    /// <summary>
    /// Запускает игру.
    /// </summary>
	public void StartGame() {
		Time.timeScale = 1;
        player.SetCanMove(true);
        State = GAME_STATE.Started;
	}

    /// <summary>
    /// Останавливает игрока.
    /// </summary>
    public void StopPlayer()
    {
        player.SetCanMove(false);
    }

    /// <summary>
    /// Ставит игру на паузу.
    /// </summary>
	public void PauseGame() {
		Time.timeScale = 0;
        State = GAME_STATE.Pause;
    }

    /// <summary>
    /// Снимает игру с паузы.
    /// </summary>
	public void ResumeGame() {
		Time.timeScale = 1;
        State = GAME_STATE.Started;
    }

    /// <summary>
    /// Рестартует игру, возвращая игрока к последнему чекпоинту.
    /// </summary>
	public void RestartGame() {
        SceneManager.LoadScene("SampleScene");
        if (checkPoint != null)
            player.transform.position = checkPoint.transform.position;
        Time.timeScale = 1;
        State = GAME_STATE.Started;
    }

    /// <summary>
    /// Завершает игру при проигрыше.
    /// </summary>
	public void GameOver() {
		Time.timeScale = 0;
		GameOverEvent();
        State = GAME_STATE.Over;
    }

    /// <summary>
    /// Выходит из игры.
    /// </summary>
	public void QuitGame() {
		Application.Quit();
	}

    /// <summary>
    /// Активация чекпоинта.
    /// </summary>
    /// <param name="point">Чекпоинт</param>
    public void ActivateCheckPoint( GameObject point )
    {
        checkPoint = point;
    }

    /// <summary>
    /// Завершает игру по достижению цели.
    /// </summary>
    public void EndGame()
    {
        fader.SetActive(true);
        Invoke("QuitGame", 3);
    }
}
