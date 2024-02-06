using UnityEngine;

public class CoinController : MonoBehaviour
{
    public float respawnTime = 5f; 
    public float spinSpeed = 100f;
    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.position; 
    }

    private void Update()
    {

        if (gameObject.activeSelf)
        {
            Debug.Log("Coin is spinning.");
            transform.Rotate(Vector3.up * spinSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            Debug.Log("Coin collected. Respawning in " + respawnTime + " seconds.");
        
            Invoke("RespawnCoin", respawnTime);
        }
    }

    private void RespawnCoin()
    {
     
        gameObject.SetActive(true);
        Debug.Log("Coin respawned.");
 
        transform.position = originalPosition;
    }
}
