using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject _laserPrefab;

    [SerializeField]
    private GameObject _tripleShootPrefab;

    [SerializeField]
    private float speed = 5.0f;

    [SerializeField]
    private float _fireRate = 0.25f;

    private float _canFire = 0.0f;

    public bool isPauseGame = false;

    public bool canTripleShot = false;

    public bool isSpeedBoost = false;

    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, -4.2f, 0);

        _audioSource = GetComponent<AudioSource>();
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
        if (!isPauseGame)
        {
            if (Time.time > _canFire)
            {
                _audioSource.Play();
                if (canTripleShot)
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

    public void TripleShotPowerUpOn()
    {
        canTripleShot = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    public IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5);
        canTripleShot = false;
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
}