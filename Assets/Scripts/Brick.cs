using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{

    [SerializeField] private Material matG;
    [SerializeField] private Material matY;
    [SerializeField] private Material matR;
    private Material[] matArray;
    private int health = 3;
    [SerializeField] private BounceSound breakMaster;

    // Start is called before the first frame update
    void Start()
    {
        matArray = new Material[] {matR, matY};
        GetComponent<MeshRenderer>().material = matG;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Ball")
        {
            health = health - 1;

            if (health < 1)
            {
                //breakMaster.playAudio();
                gameObject.transform.parent.GetComponent<BounceSound>().playAudio();
                transform.parent.GetComponent<BrickCount>().removeBlocks();
                Destroy(gameObject, 0.01f);
                return; //Return because it is not instant (Just in case code is added underneath)
            }
            else
            {
                GetComponent<MeshRenderer>().material = matArray[health-1];
            }
        }
    }
}
