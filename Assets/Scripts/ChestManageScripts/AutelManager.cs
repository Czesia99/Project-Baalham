using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutelManager : MonoBehaviour
{
    public GameObject player;

    private bool open;
    private bool croc;
    private bool fourrure;
    private bool sceptre;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) 
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (player.GetComponent<PlayerController>().openingChest == true && open == false)
        {
            open = true;
            sceptre = player.GetComponent<Inventory>().sceptre;
            fourrure = player.GetComponent<Inventory>().fourrure;
            croc = player.GetComponent<Inventory>().croc;
            if (sceptre && fourrure && croc)
            {
                Debug.Log("IN AUTEL");
                SceneManager.LoadScene(2);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        player.GetComponent<PlayerController>().openingChest = false;
    }
}
