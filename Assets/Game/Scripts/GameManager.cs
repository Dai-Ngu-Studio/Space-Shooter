using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool TroChoiKetThuc = true;

    public GameObject player;

    private UIManager _screenManagerment;

    private void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        _screenManagerment = GameObject.Find("HinhNenMenu").GetComponent<UIManager>();
    }

    private void Update()
    {
        if (TroChoiKetThuc)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(player, new Vector3(0, -4.2f, 0), Quaternion.identity);
                TroChoiKetThuc = false;
                _screenManagerment.HideTitleScreen();
            }
        }
    }
}
