using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] private float zValue;
    [SerializeField] private int killY;
    private Rigidbody myBody;
    [SerializeField] private float bounce = 15;
    [SerializeField] private GameObject gameMaster;
    private Vector3 startPos; //new Vector3(0, -3.55f, 0.03f); //y: -1.07f
    private bool ballDown = false;
    private Singleplayer game;


    // Start is called before the first frame update
    void Start()
    {
        startPos =  new Vector3(0, 0, zValue);
        myBody = GetComponent<Rigidbody>();
        transform.position = startPos;
        myBody.velocity = new Vector3(0, -2, 0);
        game = gameMaster.GetComponent<Singleplayer>();
    }

    // Update is called once per frame
    void Update()
    {
        //set z
        transform.position = new Vector3(transform.position.x, transform.position.y, zValue);

        //Call Reset Ball
        if((transform.position.y < -5.6f
            || transform.position.x > 13.2
            || transform.position.x < -13.2)
            && !ballDown) //It would keep resetting otherwise
        {
            StartCoroutine(resetBall(1f));
        }

        //Unstick
        if(myBody.velocity.y < 0.5f && myBody.velocity.y > -0.5f
            && transform.position.y > startPos.y +0.1f) //0.1 added for wiggle room. Now it doesnt rise at the start
        {
            myBody.velocity = new Vector3(myBody.velocity.x, myBody.velocity.y * 5, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "UpPush") //Up
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            myBody.velocity = new Vector3 (myBody.velocity.x, bounce, 0); //transform.up * 
        }
        else if (other.tag == "LeftPush") //Left
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            myBody.velocity = new Vector3(-bounce/3, bounce, 0);
        }
        else if (other.tag == "RightPush")
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            myBody.velocity = new Vector3(bounce/3, bounce, 0);
        }
        else if (other.tag == "LeftStatic") //Left
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            myBody.velocity = new Vector3(-bounce / 3, myBody.velocity.y, 0);
        }
        else if (other.tag == "RightStatic")
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            myBody.velocity = new Vector3(bounce / 3, myBody.velocity.y, 0);
        }
        else if (other.tag == "DownPush")
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            myBody.velocity = new Vector3(myBody.velocity.x, -bounce, 0);
        }

        randomBounce();
    }

    private void randomBounce() //private void OnCollisionEnter(Collision collision)
    {
        //Adds a random direction to each bounce
        if(Random.Range(-1, 1) < 0) //(-1 to 0)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            myBody.AddForce(bounce / 3, 0, 0);
        }
        else
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            myBody.AddForce(-bounce / 3, 0, 0);
        }
        
    }

    private IEnumerator resetBall(float amount)
    {
        ballDown = true; //Flag variable
        game.removeHealth();
        yield return new WaitForSeconds(amount);
        if(game.getHealth() > 0)
        {
            myBody.velocity = new Vector3(0, -2, 0); //Resets velocity
            transform.position = startPos;
            Debug.Log("Ball Reset");
            ballDown = false;
        }

        //Ball remains flying if you lose I guess.
    }
}
