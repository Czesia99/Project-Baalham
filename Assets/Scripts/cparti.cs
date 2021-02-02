using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cparti : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        player.transform.Rotate(new Vector3(0f, 180f, 0f));
    }
}
