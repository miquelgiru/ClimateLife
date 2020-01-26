using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ObstacleSize { SMALL, MEDIUM, LARGE}
public enum ObstacleType { WALL, STUN, BRIDGE, NONE}

public class Obstacle : MonoBehaviour
{
    public ObstacleSize Size;
    public ObstacleType Type;
    public Vector3 Offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
