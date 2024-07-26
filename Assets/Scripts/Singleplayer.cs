using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Singleplayer : MonoBehaviour
{
    [SerializeField] private int health = 5;
    [SerializeField] private Image[] healthIcons;
    [SerializeField] private GameObject backgroundCanvas;
    [SerializeField] private GameObject foregroundCanvas;
    private Transform[] foregroundObjects;
    private bool won = false;
    // Start is called before the first frame update
    void Start()
    {
        updateHealthIcons();

        foregroundObjects = new Transform[foregroundCanvas.transform.childCount];
        for (int i = 0; i < foregroundCanvas.transform.childCount; i++)
        {
            foregroundObjects[i] = foregroundCanvas.transform.GetChild(i);
        }
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public int getHealth()
    {
        return health;
    }

    public void removeHealth()
    {
        if (!won)
        {
            health--;
            updateHealthIcons();
            if (health > 0)
            {
                GetComponent<BounceSound>().playBounceSound();

                return;
            }

            GetComponent<BounceSound>().playAudio();

            //Start loss sequence
            foregroundObjects[0].gameObject.SetActive(true);
            foregroundObjects[2].gameObject.SetActive(true);
        }
        

    }

    public void addHealth()
    {
        health++;
        updateHealthIcons();
    }

    public void updateHealthIcons()
    {
        //Health Management
        for (int i = 0; i < healthIcons.Length; i++)
        {
            if (i + 1 > health)
            {
                healthIcons[i].enabled = false;
            }
            else
            {
                healthIcons[i].enabled = true;
            }
        }
    }

    public void win()
    {
        //Win sequence
        won = true;
        GetComponent<BounceSound>().playAudio3();
        foregroundObjects[1].gameObject.SetActive(true);
        foregroundObjects[2].gameObject.SetActive(true);
    }
}
