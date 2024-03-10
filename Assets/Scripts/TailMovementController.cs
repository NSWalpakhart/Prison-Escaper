using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TailMovementController : MonoBehaviour
{
    CopMovementController _snakeHead;
    private float _speed;
    private int _index;
    private Vector3 _tailTarget;
    private GameObject _tailTargetObject;

    private void Start()
    {
        _snakeHead = GameObject.FindGameObjectWithTag("SnakeHead").GetComponent<CopMovementController>();
        _speed = _snakeHead.GetSpeed();
        _tailTargetObject = _snakeHead.Tails[_snakeHead.Tails.Count - 2];

    }

    private void FixedUpdate()
    {
        _tailTarget = _tailTargetObject.transform.position;
    }

    private void Update()
    {
        transform.LookAt(_tailTarget);
        transform.position = Vector3.Lerp(transform.position, _tailTarget, Time.deltaTime * _speed);
        _index = _snakeHead.Tails.IndexOf(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SnakeHead"))
        {
            if (_index > 3)
                SceneManager.LoadScene("Menu");

        }
        if (other.CompareTag("Food"))
        {
            Destroy(_snakeHead.Tails[_snakeHead.Tails.Count-1]);
            _snakeHead.Tails.RemoveAt(_snakeHead.Tails.Count - 1);
        }
        if (other.CompareTag("Border"))
            SceneManager.LoadScene("Menu");
    }
}
