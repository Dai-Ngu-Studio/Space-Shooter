using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject _laserPrefab;

    [SerializeField]
    private GameObject _tripleShootPrefab;

    [SerializeField]
    private GameObject _explosionPrefab;

    [SerializeField]
    private GameObject _shieldGameObject;

    [SerializeField]
    private GameObject[] _engines;

    [SerializeField]
    private float VanDoc = 5.0f;

    [SerializeField]
    private float _fireRate = 0.25f;

    private float CoTheBan = 0.0f;

    public bool _DaDung = false;

    public bool Ban3tia = false;

    public bool chayNhanh = false;

    public bool DangCoGiap = false;

    public int Mang = 3;

    private int total_hit_amount = 0;

    private SpawnManager _spawnManager;

    private UIManager QuanLyUI;

    private GameManager gameManagement;

    private AudioSource AmThanh;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0.09f, -4.2f, 0);

        AmThanh = GetComponent<AudioSource>();

        QuanLyUI = GameObject.Find("HinhNenMenu").GetComponent<UIManager>();

        if(QuanLyUI != null)
        {
            QuanLyUI.UpdateLives(Mang);
        }

        gameManagement = GameObject.Find("GameManager").GetComponent<GameManager>();

        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        if(_spawnManager != null)
        {
            _spawnManager.StartSpawnRoutine();
        }

        total_hit_amount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ChayDiChuyen();

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
            Ban();
        }
    }

    private void ChayDiChuyen()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (chayNhanh)
        {
            transform.Translate(Vector3.right * VanDoc * horizontalInput * Time.deltaTime * 1.5f);
            transform.Translate(Vector3.up * VanDoc * verticalInput * Time.deltaTime * 1.5f);
        }
        else
        {
            transform.Translate(Vector3.right * VanDoc * horizontalInput * Time.deltaTime);
            transform.Translate(Vector3.up * VanDoc * verticalInput * Time.deltaTime);
        }


        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -4.2)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }

        if (transform.position.x > 8)
        {
            transform.position = new Vector3(8f, transform.position.y, 0);
        }
        else if (transform.position.x < -8)
        {
            transform.position = new Vector3(-8f, transform.position.y, 0);
        }
    }

    private void Ban()
    {
        if (!_DaDung)
        {
            if (Time.time > CoTheBan)
            {
                AmThanh.Play();
                if (Ban3tia)
                {
                    Instantiate(_tripleShootPrefab, transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
                }
                CoTheBan = Time.time + _fireRate;
            }
        }
    }

    public void Damage()
    {
        if (DangCoGiap)
        {
            DangCoGiap = false;
            _shieldGameObject.SetActive(false);
            return;
        }

        QuanLyUI.UpdateLives(--Mang);

        total_hit_amount++;

        if (total_hit_amount == 1)
        {
            _engines[0].SetActive(true);
        }
        else if (total_hit_amount == 2)
        {
            _engines[1].SetActive(true);
        }

        if (Mang < 1)
        {
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            gameManagement.TroChoiKetThuc = true;
            QuanLyUI.ShowTitleScreen();
            Destroy(this.gameObject);
        }
        
    }

    public void AnBan3tia()
    {
        Ban3tia = true;
        StartCoroutine(HetBan3Tia());
    }

    public IEnumerator HetBan3Tia()
    {
        yield return new WaitForSeconds(5);
        Ban3tia = false;
    }

    public void AnChayNhanh()
    {
        chayNhanh = true;
        StartCoroutine(SpeedBoostPowerDownRoutine());
    }

    public IEnumerator SpeedBoostPowerDownRoutine()
    {
        yield return new WaitForSeconds(5);
        chayNhanh = false;
    }

    public void AnGiap()
    {
        DangCoGiap = true;
        _shieldGameObject.SetActive(true);
    }
}