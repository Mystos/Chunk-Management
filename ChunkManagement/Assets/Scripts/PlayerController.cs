using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;
    public float speed = 6;
    public float rotSpeed;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        transform.Rotate(Vector3.up, horizontal * rotSpeed);
        controller.Move(transform.forward * vertical * speed * Time.deltaTime);
    }
}
