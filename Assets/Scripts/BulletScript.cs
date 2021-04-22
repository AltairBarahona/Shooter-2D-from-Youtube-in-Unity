using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    private Vector2 Direction;
    public float bulletSpeed;

    public AudioClip bulletSound;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D=GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(bulletSound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
        Rigidbody2D.velocity=Direction*bulletSpeed;
    }

    public void SetDirection(Vector2 direction){
        Direction=direction;
    }

    public void DestroyBullet(){
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider){
        JohnMovement john= collider.GetComponent<JohnMovement>();
        GruntScript grunt= collider.GetComponent<GruntScript>();
        

        
        if (john!=null)
        {
            john.OnBulletHit();
        DestroyBullet();

        }
        
        if (grunt!=null)
        {
            grunt.OnBulletHit();
        DestroyBullet();

        }
        DestroyBullet();


    }
}
