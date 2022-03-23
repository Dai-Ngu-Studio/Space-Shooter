using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool TroChoiKetThuc = true;

    public GameObject nguoiChooi;

    private UIManager a;

    private void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        a = GameObject.Find("HinhNenMenu").GetComponent<UIManager>();
    }

    private void Update()
    {
        if (TroChoiKetThuc)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(nguoiChooi, new Vector3(0.01f, -4.2f, 0), Quaternion.identity);
                TroChoiKetThuc = false;
                a.AnManHinhTitle();
            }
        }
    }
}
