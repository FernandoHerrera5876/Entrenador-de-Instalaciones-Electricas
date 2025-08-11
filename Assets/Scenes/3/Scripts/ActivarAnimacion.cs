using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarAnimacion : MonoBehaviour
{
   

    public Animator animacion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            
            animacion.enabled = false;
            
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            
            animacion.enabled = true;
        }
    }
}
