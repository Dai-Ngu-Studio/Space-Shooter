using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float VanTocPowerup = 3.0f;

    [SerializeField]
    private int IdTangSucManh; // 0: TripleShot; 1: Speed; 2: Shield

    [SerializeField]
    private AudioClip TiengPowerUp; //sound when player pick it

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * VanTocPowerup * Time.deltaTime);

        if (transform.position.y < -7)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player NguoiChoi = other.GetComponent<Player>();

            AudioSource.PlayClipAtPoint(TiengPowerUp, Camera.main.transform.position, 1f);

            if (NguoiChoi != null)
            {
                if (IdTangSucManh == 0)
                {
                    NguoiChoi.AnBan3tia();
                }
                else if (IdTangSucManh == 1)
                {
                    NguoiChoi.AnChayNhanh();
                }
                else if (IdTangSucManh == 2)
                {
                    NguoiChoi.AnGiap();
                }
            }
            Destroy(this.gameObject);
        }
    }
}
