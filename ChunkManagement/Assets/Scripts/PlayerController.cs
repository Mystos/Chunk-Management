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
        //transform.rotation = Quaternion.Euler(new Vector3(0f, transform.rotation.eulerAngles.y + horizontal * turnSpeed, 0f));
        Vector3 movDir = new Vector3(0, 0, vertical);
        controller.Move(movDir.normalized * speed * Time.deltaTime);
    }
}
