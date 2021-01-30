using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public MazeSpawner mazePrefabs;
    private MazeSpawner mazeInstance;
    // Start is called before the first frame update
    void Start()
    {
        BeginGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            RestartGame();
    }

    private void BeginGame()
    {
        mazeInstance = Instantiate(mazePrefabs) as MazeSpawner;

    }

    private void RestartGame()
    {
    foreach (Transform child in mazeInstance.transform)
            GameObject.Destroy(child.gameObject);
        Destroy(mazeInstance.gameObject);
        BeginGame();
    }
}
