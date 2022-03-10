using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;

    [SerializeField]
    private int powerUpId; // 0: TripleShot; 1: Speed; 2: Shield

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                if (powerUpId == 0)
                {
                    player.TripleShotPowerUpOn();
                }
                else if (powerUpId == 1)
                {
                    player.SpeedBoostPowerUpOn();
                }
                else if (powerUpId == 2)
                {
                    player.ShieldPowerUpOn();
                }
            }
            Destroy(this.gameObject);
        }
    }
}
