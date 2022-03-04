using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameOver = true;

    public GameObject player;

    private UIManager _uIManager;

    private void Start()
    {
        _uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    private void Update()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(player, new Vector3(0, -4.2f, 0), Quaternion.identity);
                gameOver = false;
                _uIManager.HideTitleScreen();
            }
        }
    }
}
