using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//울퉁불퉁한 지면을 움직이기 위한 forcereciever -> 강의 내용 활용
public class ForceReciever : MonoBehaviour
{
    [SerializeField] private CharacterController controller;

    private float verticalVelocity;

    public Vector3 Movement => Vector3.up * verticalVelocity;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            verticalVelocity = Physics.gravity.y * Time.deltaTime;
        }
        else
        {
            verticalVelocity += Physics.gravity.y * Time.deltaTime;
        }
    }
}
