using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyExplosionPrefab; 

    [SerializeField]
    private AudioClip AmTHanhEnemy;

    private UIManager QuanLyUI;

    private GameManager abc;

    private float _speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        QuanLyUI = GameObject.Find("HinhNenMenu").GetComponent<UIManager>();
        abc = GameObject.Find("GameManager").GetComponent<GameManager>();
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

        if (abc.TroChoiKetThuc)
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
            AudioSource.PlayClipAtPoint(AmTHanhEnemy, Camera.main.transform.position, 1f);
            Destroy(this.gameObject);
            QuanLyUI.UpdateScore();
        }
        else if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
            }
            Instantiate(_enemyExplosionPrefab, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(AmTHanhEnemy, Camera.main.transform.position, 1f);
            Destroy(this.gameObject);
        }
    }
}
