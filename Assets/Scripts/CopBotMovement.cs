using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CopBotMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private GameObject EnemyObject;

    private void Start()
    {
        Application.targetFrameRate = 144;
    }
    void Update()
    {
        EnemyObject = GameObject.FindGameObjectWithTag("Food");
        MoveCop();
        
    }


    private void MoveCop()
    {
        transform.LookAt(EnemyObject.transform.position);
        Vector3 currentPosition = transform.position;
        Vector3 targetPosition = new Vector3(EnemyObject.transform.position.x, currentPosition.y, EnemyObject.transform.position.z);
        transform.position = Vector3.MoveTowards(currentPosition, targetPosition, _speed * Time.deltaTime);

    }

    public float GetSpeed()
    {
        return _speed;
    }

    
}
