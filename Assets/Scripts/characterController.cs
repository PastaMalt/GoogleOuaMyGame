using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public float speed = 4.0f;
    Rigidbody2D rb2d;
    Animator anim;
    Transform charTrans;
    SpriteRenderer spRender;
    [SerializeField] GameObject cam;

    

    void Start()
    {
       spRender = GetComponent<SpriteRenderer>();
        //caching rb2d yani önbellek                                    
       anim = GetComponent<Animator>();
       rb2d = GetComponent<Rigidbody2D>();
       charTrans = GetComponent<Transform>();

    }
    private void FixedUpdate() //fizik hesaplamalarý fixed update de yapýlýr
    {
       // rb2d.velocity = new Vector2(speed, 0f);
        
    }



    void Update() //per frame
    {

        charTrans.position = new Vector3(charTrans.position.x + (Input.GetAxis("Horizontal") * speed * Time.deltaTime), charTrans.position.y);
         
        if(Input.GetAxis("Horizontal") == 0.0f)
        {
            anim.SetFloat("speed", 0.0f); //set deðeri atamak
        }
        else
        {
            anim.SetFloat("speed", 1.0f);       
        }

        if (Input.GetAxis("Horizontal") > 0.01f)
        {
            spRender.flipX = false;
        }
        else if (Input.GetAxis("Horizontal") < -0.01f)
        {
            spRender.flipX = true;
        }
    }

    void LateUpdate()
    { 
        cam.transform.position = new Vector3(charTrans.position.x, charTrans.position.y, charTrans.position.z -1.0f);
    }
}
