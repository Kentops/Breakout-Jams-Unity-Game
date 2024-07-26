using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceSound : MonoBehaviour
{
    [SerializeField] private GameObject source1;
    [SerializeField] private GameObject source2;
    [SerializeField] private GameObject source3;
    [SerializeField] bool playOnHit = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Collision sound
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball" && playOnHit)
        {
            source1.GetComponent<AudioSource>().Play();
        }
    }

    //Activated sound
    public void playAudio()
    {
        source2.GetComponent<AudioSource>().Play();
    }

    public void playBounceSound()
    {
        source1.GetComponent<AudioSource>().Play();
    }

    public void playAudio3()
    {
        source3.GetComponent<AudioSource>().Play();
    }
}
