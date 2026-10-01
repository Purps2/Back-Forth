using UnityEngine;

public class GemManager : MonoBehaviour
{
    public bool leftGemActive = false;
    public bool rightGemActive = true;

    public void LeftGemCollected()
    {
        leftGemActive = false;
        rightGemActive = true;

        Debug.Log("Right Gem is Falling!");
    }

    public void RightGemCollected()
    {
        leftGemActive = true;
        rightGemActive = false;

        Debug.Log("Left Gem is Falling!");
    }

    public void GemMissed()
    {
        leftGemActive = false;
        rightGemActive = false;
    }

    void Start()
    {
        
    }

 
    void Update()
    {

    }
    private void OnDestroy()
    {
        
    }
}
