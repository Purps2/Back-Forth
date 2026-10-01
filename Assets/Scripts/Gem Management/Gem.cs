using UnityEngine;

public class Gem : MonoBehaviour
{
    public GemManager gemManager;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Gem Collected!");

            if(gemManager != null)
            {
                if (gemManager.rightGemActive)
                {
                    gemManager.RightGemCollected();
                }
                else if (gemManager.leftGemActive)
                {
                    gemManager.LeftGemCollected();
                }
            }

            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Gem missed!");

            if (gemManager != null)
            {
                gemManager.GemMissed();
            }

            Destroy(gameObject);
        }
    }

}
