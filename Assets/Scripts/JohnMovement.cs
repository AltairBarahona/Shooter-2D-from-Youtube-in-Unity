using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnMovement : MonoBehaviour
{
    public GameObject BulletPrefab;
    public GameObject BulletPrefabQ;

    private Rigidbody2D rigidBody2D;
    private float horizontal;
    public float jumpForce;
    public float speed;
    private bool grounded;
    private float lastShoot;
    private Animator animator;
    private bool derecha, izquierda;

    private int health;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D=GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
        health=7;
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal=Input.GetAxisRaw("Horizontal");
        

        // if (horizontal<0.0f)
        // {
        //     transform.localScale=new Vector3(-1.0f,1.0f,1.0f);
        // }else if(horizontal>0.0f){
        //     transform.localScale=new Vector3(1.0f,1.0f,1.0f);
        // }
        
        // animator.SetBool("Running",horizontal !=0.0f);

        Debug.DrawRay(transform.position, Vector2.down*0.1f, Color.red);
        if (Physics2D.Raycast(transform.position,Vector2.down,0.1f))
        {
            grounded=true;
        }else{
            grounded=false;
        }

        if(Input.GetKeyDown(KeyCode.UpArrow)&&grounded==true){
            Jump();
        }

    //probar otras formas de disparar en automático divertidas
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     Shoot();
        // }

        // if (Input.GetKey(KeyCode.Q))
        // {
        //     ShootQ();
            
        // }

        if (Input.GetKey(KeyCode.Space)&&Time.time>lastShoot+0.25)
        {
            print("disparando");
            Shoot();
            lastShoot=Time.time;
        }
    }

    private void FixedUpdate(){

        
        
        if (derecha=Input.GetKey(KeyCode.RightArrow))
        {
            transform.localScale=new Vector3(1.0f,1.0f,1.0f);

                rigidBody2D.velocity= new Vector2(horizontal*speed, rigidBody2D.velocity.y);
        animator.SetBool("Running",true);

                
        }else if (izquierda=Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localScale=new Vector3(-1.0f,1.0f,1.0f);

            rigidBody2D.velocity= new Vector2(horizontal*speed, rigidBody2D.velocity.y);
        animator.SetBool("Running",true);

        }else{
        animator.SetBool("Running",false);

        }

        
        
        
        // rigidBody2D.velocity= new Vector2(horizontal*speed, rigidBody2D.velocity.y);
    }

    private void Jump(){
        rigidBody2D.AddForce(Vector2.up*jumpForce);
    }

    private void Shoot(){
        Vector3 directionPlayer;

        if (transform.localScale.x==1)
        {
            directionPlayer=Vector2.right;
        }else{
            directionPlayer=Vector2.left;

        }
        GameObject bullet= Instantiate(BulletPrefab,transform.position+directionPlayer*0.2f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDirection(directionPlayer);
    }
    private void ShootQ(){
        Vector3 directionPlayer;

        if (transform.localScale.x==1)
        {
            directionPlayer=Vector2.right;
        }else{
            directionPlayer=Vector2.left;

        }
        GameObject bulletQ= Instantiate(BulletPrefabQ,transform.position+directionPlayer*0.2f, Quaternion.identity);
        bulletQ.GetComponent<BulletScript>().SetDirection(directionPlayer);
    }

    public void OnBulletHit(){
        health-=1;
        if (health==0)
        {
        
            Destroy(gameObject);
            

        
        }
    }
}
