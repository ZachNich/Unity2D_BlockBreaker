using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    SceneLoader sceneLoader;
    int blocksRemaining;

    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
    
    public void AddBlock()
    {
        blocksRemaining++;
    }

    public void RemoveBlock()
    {
        blocksRemaining--;
        if (blocksRemaining <= 0) sceneLoader.LoadNextScene();
    }
}
