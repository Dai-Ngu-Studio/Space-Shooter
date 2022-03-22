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
    private float speed = 5.0f;

    [SerializeField]
    private float _fireRate = 0.25f;

    private float _canFire = 0.0f;

    public bool isGameStopped = false;

    public bool canTripleFireShot = false;

    public bool isSpeedBoost = false;

    public bool isShieldActive = false;

    public int lives = 3;

    private int hitCount = 0;

    private SpawnManager _spawnManager;

    private UIManager _uiMananger;

    private GameManager _playManagerment;

    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, -4.2f, 0);

        _audioSource = GetComponent<AudioSource>();

        _uiMananger = GameObject.Find("Canvas").GetComponent<UIManager>();

        if(_uiMananger != null)
        {
            _uiMananger.UpdateLives(lives);
        }

        _playManagerment = GameObject.Find("GameManager").GetComponent<GameManager>();

        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        if(_spawnManager != null)
        {
            _spawnManager.StartSpawnRoutine();
        }

        hitCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
            Shoot();
        }
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (isSpeedBoost)
        {
            transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime * 1.5f);
            transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime * 1.5f);
        }
        else
        {
            transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
            transform.Translate(Vector3.up * speed * verticalInput * Time.deltaTime);
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

    private void Shoot()
    {
        if (!isGameStopped)
        {
            if (Time.time > _canFire)
            {
                _audioSource.Play();
                if (canTripleFireShot)
                {
                    Instantiate(_tripleShootPrefab, transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
                }
                _canFire = Time.time + _fireRate;
            }
        }
    }

    public void Damage()
    {
        if (isShieldActive)
        {
            isShieldActive = false;
            _shieldGameObject.SetActive(false);
            return;
        }

        _uiMananger.UpdateLives(--lives);

        hitCount++;

        if (hitCount == 1)
        {
            _engines[0].SetActive(true);
        }
        else if (hitCount == 2)
        {
            _engines[1].SetActive(true);
        }

        if (lives < 1)
        {
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            _playManagerment.gameEnd = true;
            _uiMananger.ShowTitleScreen();
            Destroy(this.gameObject);
        }
        
    }

    public void TripleShotPowerUpOn()
    {
        canTripleFireShot = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    public IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5);
        canTripleFireShot = false;
    }

    public void SpeedBoostPowerUpOn()
    {
        isSpeedBoost = true;
        StartCoroutine(SpeedBoostPowerDownRoutine());
    }

    public IEnumerator SpeedBoostPowerDownRoutine()
    {
        yield return new WaitForSeconds(5);
        isSpeedBoost = false;
    }

    public void ShieldPowerUpOn()
    {
        isShieldActive = true;
        _shieldGameObject.SetActive(true);
    }
}