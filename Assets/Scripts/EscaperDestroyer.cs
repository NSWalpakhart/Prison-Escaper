using System.Collections;
using UnityEngine;

public class EscaperDestroyer : MonoBehaviour
{ 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SnakeHead"))
        {
            other.GetComponent<CopMovementController>().AddTailPart();
            Destroy(gameObject);
        }
    }
}
