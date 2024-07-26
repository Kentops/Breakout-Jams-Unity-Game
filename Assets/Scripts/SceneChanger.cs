using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    //Using tutorial: https://www.youtube.com/watch?v=NRUk7YzXyhE
    [SerializeField] private string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
