using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsChecker : MonoBehaviour
{
    public float cameraWidth, cameraHeight;

    public float gameBoarderRadius = 1f;
    
    void Awake()
    {
        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = cameraHeight * Camera.main.aspect;
    }
    void OnDrawBoards()
    {
        if (!Application.isPlaying) return;
        Vector3 playfieldSize = new Vector3(cameraWidth, cameraHeight, 0.1f);
        Gizmos.DrawWireCube(Vector3.zero, playfieldSize);
    }
    
}
