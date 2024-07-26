using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickCount : MonoBehaviour
{
    private int blocks = 36;
    [SerializeField] private GameObject gameMaster;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void removeBlocks()
    {
        blocks--;

        if(blocks <= 0)
        {
            //Start the win sequence
            gameMaster.GetComponent<Singleplayer>().win();
        }
    }
}
