using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashSequence : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ToExit());
    }

    IEnumerator ToExit() 
    {
        yield return new WaitForSeconds(60);
        Application.Quit();
    }
}
