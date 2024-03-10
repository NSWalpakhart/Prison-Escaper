using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscaperPlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    Joystick Joystick;
    private void Start()
    {
        Application.targetFrameRate = 144;
        Joystick = FindObjectOfType<Joystick>();
    }
    void Update()
    {
        Move();
    }


    private void Move()
    {
        Vector3 transforms = gameObject.transform.position;
        transforms = new Vector3(Joystick.Horizontal, 0f, Joystick.Vertical);
        gameObject.transform.Translate(transforms * _speed * Time.deltaTime, Space.Self);
        float angle = Joystick.Horizontal * 60 * Time.deltaTime;
        transform.Rotate(0, angle, 0);
        /*Vector3 transforms = gameObject.transform.position;
        transforms = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        gameObject.transform.Translate(transforms * _speed * Time.deltaTime, Space.Self);
        float angle = Input.GetAxis("Horizontal") * 60 * Time.deltaTime;
        transform.Rotate(0, angle, 0);*/
    }





}
