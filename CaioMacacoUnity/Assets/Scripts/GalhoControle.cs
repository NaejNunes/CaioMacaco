using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalhoControle : MonoBehaviour
{
    private float timeDestroy = 6;
    private bool checkGalho = false;
    public void FixedUpdate()
    {
        if (checkGalho == true)
            timeDestroy -= Time.deltaTime;

        if (timeDestroy <= 3)
            GetComponent<Animator>().SetBool("QuebrarGalho", true);

        if (timeDestroy <= 0)
            Destroy(this.gameObject);
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            checkGalho = true;
            timeDestroy = 6;
        }
    }
}
