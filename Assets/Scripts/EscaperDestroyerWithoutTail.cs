using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscaperDestroyerWithoutTail : MonoBehaviour
{
    GameTimer helper;

    private void Start()
    {
        helper = FindObjectOfType<GameTimer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject)
        {
            if (other.CompareTag("SnakeHead"))
            {
                Destroy(gameObject);
                helper.MinusScore();

            }
        }
    }
}
