using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "car")
        {
            CutsceneManager.Instance.EndGame();
        }
    }
}
