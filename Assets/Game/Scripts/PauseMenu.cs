using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameUI;

    [SerializeField]
    private GameObject _pauseUI;

    private Player _player;
    private GameManager _playManagerment;

    // Start is called before the first frame update
    void Start()
    {
        _pauseUI = transform.GetChild(0).gameObject;

        _playManagerment = GameObject.Find("GameManager").GetComponent<GameManager>();


        if (!_playManagerment.TroChoiKetThuc)
        {
            _player = GameObject.Find("Player").GetComponent<Player>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_playManagerment != null)
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
            _player._DaDung = true;
        }
        _gameUI.SetActive(false);
        _pauseUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        if (_player != null)
        {
            _player._DaDung = false;
        }
        _gameUI.SetActive(true);
        _pauseUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void QuitGame() => Application.Quit();
}
