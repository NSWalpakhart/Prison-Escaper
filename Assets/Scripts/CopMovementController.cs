using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CopMovementController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    private List<GameObject> tails=new List<GameObject>();
    [SerializeField] private GameObject _tailObject;
    public Text ScoreText;
    private int _score=0;
    private void Start()
    {
        Application.targetFrameRate = 144;
        tails.Add(gameObject);
    }
    void Update()
    {
        _score=Tails.Count-1;
        ScoreText.text = _score.ToString();
        MoveCop();
        LeftTouchMove();
        RightTouchMove();
    }

    
    private void MoveCop()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        float angle = Input.GetAxis("Horizontal") * _rotationSpeed * Time.deltaTime;
        transform.Rotate(0, angle, 0);
    }

    public void LeftTouchMove()
    {
        float angle = -1 * _rotationSpeed*10 * Time.deltaTime;
        transform.Rotate(0, angle, 0);
    }

    public void RightTouchMove()
    {
        float angle = 1 * _rotationSpeed*10 * Time.deltaTime;
        transform.Rotate(0, angle, 0);
    }

    public float GetSpeed()
    {
        return _speed;
    }
    public float GetScore()
    {
        return _score;
    }

    public List<GameObject> Tails
    {
        get
        {
            return tails;
        }
    }
    public void AddTailPart()
    {
        _speed += 0.1f;
        Vector3 newPartTailPos = tails[tails.Count - 1].transform.position;
        tails.Add(GameObject.Instantiate(_tailObject, newPartTailPos, Quaternion.identity));
    }

}
