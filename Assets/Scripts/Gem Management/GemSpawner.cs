using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    public Transform leftSpawner;
    public Transform rightSpawner;

    public GameObject gemPrefab;

    public GemManager gemManager;

    public void SpawnLeftGem()
    {
        Debug.Log("SpawnLEFTGem CALLED!");

        GameObject newGem = Instantiate(
            gemPrefab,
            leftSpawner.position,
            leftSpawner.rotation
        );

        newGem.GetComponent<Gem>().gemManager = gemManager;

        Debug.Log("Spawned LEFT gem!");
    }

    public void SpawnRightGem()
    {
        Debug.Log("SpawnRightGem CALLED!");

        GameObject newGem = Instantiate(
            gemPrefab,
            rightSpawner.position,
            rightSpawner.rotation
        );

        newGem.GetComponent<Gem>().gemManager = gemManager;

        Debug.Log("Spawned RIGHT gem!");
    }
}
