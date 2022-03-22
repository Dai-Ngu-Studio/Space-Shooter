using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyShipPrefab;

    private GameManager _playManagerment;

    [SerializeField]
    private GameObject[] powerups;

    // Start is called before the first frame update
    void Start()
    {
        _playManagerment = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    IEnumerator PowerSpawnRangeTime()
    {
        while (_playManagerment.gameEnd == false)
        {
            Instantiate(enemyShipPrefab, new Vector3(Random.Range(-7f, 7f), 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(3);
        }
    }

    IEnumerator PowerUpsOnRangeTime()
    {
        while (_playManagerment.gameEnd == false)
        {   
            int randomPowerUp = Random.Range(0, powerups.Length);
            Instantiate(powerups[randomPowerUp], new Vector3(Random.Range(-7f, 7f), 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(10);
        }
    }
    public void StartSpawnRoutine()
    {
        StartCoroutine(PowerSpawnRangeTime());
        StartCoroutine(PowerUpsOnRangeTime());
    }
}