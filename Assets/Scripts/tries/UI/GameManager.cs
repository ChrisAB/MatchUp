using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject gamePanel;
    // Start is called before the first frame update
    void Start()
    {
        startPanel.SetActive(true);
        gamePanel.SetActive(false);
    }

    public void PlayGame(){
        startPanel.SetActive(false);
        gamePanel.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
