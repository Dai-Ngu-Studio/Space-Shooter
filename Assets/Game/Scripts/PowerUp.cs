using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;

    [SerializeField]
    private int powerUpId; // 0: TripleShot; 1: Speed; 2: Shield

    [SerializeField]
    private AudioClip _audioClip; //sound when player pick it

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -7)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            AudioSource.PlayClipAtPoint(_audioClip, Camera.main.transform.position, 1f);

            if (player != null)
            {
                if (powerUpId == 0)
                {
                    player.AnBan3tia();
                }
                else if (powerUpId == 1)
                {
                    player.AnChayNhanh();
                }
                else if (powerUpId == 2)
                {
                    player.AnGiap();
                }
            }
            Destroy(this.gameObject);
        }
    }
}
