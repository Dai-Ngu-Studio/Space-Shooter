using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyExplosionPrefab; 

    [SerializeField]
    private AudioClip _audioClip;

    private UIManager _screenManagermentment;

    private GameManager _gameManagerment;

    private float _speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        _screenManagermentment = GameObject.Find("Canvas").GetComponent<UIManager>();
        _gameManagerment = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -7)
        {
            float randomX = Random.Range(-7, 7);
            transform.position = new Vector3(randomX, 7, 0);
        }

        if (_gameManagerment.gameEnd)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
            if (other.transform.parent != null)
            {
                Destroy(other.transform.parent.gameObject);
            }
            Destroy(other.gameObject);
            Instantiate(_enemyExplosionPrefab, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(_audioClip, Camera.main.transform.position, 1f);
            Destroy(this.gameObject);
            _screenManagermentment.UpdateScore();
        }
        else if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
            }
            Instantiate(_enemyExplosionPrefab, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(_audioClip, Camera.main.transform.position, 1f);
            Destroy(this.gameObject);
        }
    }
}
