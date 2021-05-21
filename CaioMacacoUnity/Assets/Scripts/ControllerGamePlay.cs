using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerGamePlay : MonoBehaviour
{
    [SerializeField] protected GameObject painel;
    [SerializeField] protected float time;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;

        if (time <= 0)
            painel.SetActive(false);
    }
}
