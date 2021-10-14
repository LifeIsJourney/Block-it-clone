using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullWall : MonoBehaviour
{
    Ball ball;
    // Start is called before the first frame update
    void Start()
    {
        ball = FindObjectOfType<Ball>();
    }

   
}
