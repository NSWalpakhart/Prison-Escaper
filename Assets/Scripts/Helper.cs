using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour
{
    CopMovementController _snakeHead;
    [SerializeField] private GameObject _head;

    private void Start()
    {
        _snakeHead = GameObject.FindGameObjectWithTag("SnakeHead").GetComponent<CopMovementController>();
    }
    private void Update()
    {
        if ((_snakeHead.Tails.Count)==0)
        {
            _snakeHead.Tails.Add(_head);
        }
    }
}
