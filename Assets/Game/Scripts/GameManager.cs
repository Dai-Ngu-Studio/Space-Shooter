using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameEnd = true;

    public GameObject player;

    private UIManager _screenManagerment;

    private void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        _screenManagerment = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    private void Update()
    {
        if (gameEnd)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(player, new Vector3(0, -4.2f, 0), Quaternion.identity);
                gameEnd = false;
                _screenManagerment.HideTitleScreen();
            }
        }
    }
}
