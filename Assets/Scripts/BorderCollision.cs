using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BorderCollision : MonoBehaviour
{ 

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("SnakeHead"))
            SceneManager.LoadScene("Menu");
    }





}
