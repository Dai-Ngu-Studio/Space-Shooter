using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameUI;

    [SerializeField]
    private GameObject _pauseUI;

    private Player _player;
    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _pauseUI = transform.GetChild(0).gameObject;

        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();


        if (!_gameManager.gameOver)
        {
            _player = GameObject.Find("Player").GetComponent<Player>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameManager != null)
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        if (_player != null)
        {
            _player.isPauseGame = true;
        }
        _gameUI.SetActive(false);
        _pauseUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        if (_player != null)
        {
            _player.isPauseGame = false;
        }
        _gameUI.SetActive(true);
        _pauseUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void QuitGame() => Application.Quit();
}
