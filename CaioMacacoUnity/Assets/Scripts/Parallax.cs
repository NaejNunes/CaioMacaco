using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] protected GameObject cameraPlayer;
    [SerializeField] protected float speedParallax;

    private float length, startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = (cameraPlayer.transform.position.x * (1 - speedParallax));
        float dist = (cameraPlayer.transform.position.x * speedParallax);

        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

        if (temp > startPos + length / 2)
            startPos += length;

        else if (temp < startPos - length / 2)
            startPos -= length;
    }
}
