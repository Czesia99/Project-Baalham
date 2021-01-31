using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrocChest : MonoBehaviour
{
    public GameObject player;
    private GameObject baseChest;
    private GameObject openingChest;

    private bool open;
    
    // Start is called before the first frame update
    void Start()
    {
        baseChest = this.transform.GetChild(0).gameObject;
        openingChest = baseChest.transform.GetChild(0).gameObject;
        open = false;
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
            openingChest.transform.eulerAngles = new Vector3(-90, 0, 0);
            open = true;
            player.GetComponent<Inventory>().croc = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        player.GetComponent<PlayerController>().openingChest = false;
    }
}
