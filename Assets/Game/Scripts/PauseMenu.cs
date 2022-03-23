using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject GiaoDien;

    [SerializeField]
    private GameObject TamNgunGUI;

    private Player nguoiChoi;
    private GameManager _playManagerment;

    // Start is called before the first frame update
    void Start()
    {
        TamNgunGUI = transform.GetChild(0).gameObject;

        _playManagerment = GameObject.Find("GameManager").GetComponent<GameManager>();


        if (!_playManagerment.TroChoiKetThuc)
        {
            nguoiChoi = GameObject.Find("Player").GetComponent<Player>();
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
        if (nguoiChoi != null)
        {
            nguoiChoi._DaDung = true;
        }
        GiaoDien.SetActive(false);
        TamNgunGUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        if (nguoiChoi != null)
        {
            nguoiChoi._DaDung = false;
        }
        GiaoDien.SetActive(true);
        TamNgunGUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void QuitGame() => Application.Quit();
}
