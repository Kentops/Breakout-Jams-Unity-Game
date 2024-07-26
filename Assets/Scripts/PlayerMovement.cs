using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float speed = 1.0f;
    [SerializeField] CharacterController controller;
    [SerializeField] float yValue;
    private Vector3 translate = new Vector3 (1,0,0);
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Basic Movement
        if(Input.GetKey(KeyCode.A))
        {
            controller.Move(translate * -speed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.D))
        {
            controller.Move(translate * speed * Time.deltaTime);
        }

        //Teleportation
        if(transform.position.x >= 13.2f )
        {
            transform.position += new Vector3 (-25.5f,0,0); //f is only needed after a number with a decimal
        }

        if(transform.position.x < -13.2f)
        {
            transform.position += new Vector3(25.5f, 0, 0);
        }

        //Set y level
        transform.position = new Vector3(transform.position.x, yValue, 0);
    }
}
