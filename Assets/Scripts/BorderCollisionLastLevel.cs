using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BorderCollisionLastLevel : MonoBehaviour
{
    GameTimer helper;

    private void Start()
    {
        helper = FindObjectOfType<GameTimer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            Destroy(GameObject.FindGameObjectWithTag("Food"));
            helper.MinusScore();

        }
    }





}
