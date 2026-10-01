using UnityEngine;

public class Gem : MonoBehaviour
{
    public GemManager gemManager;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Gem Collected!");

            Destroy(gameObject);
        }
        else;
        {
            Debug.Log("Gem hit something else!");

            gemManager.GemMissed();

            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
