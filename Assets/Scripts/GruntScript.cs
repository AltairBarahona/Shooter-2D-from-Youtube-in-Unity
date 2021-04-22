using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntScript : MonoBehaviour
{
    public GameObject John;
    public GameObject BulletPrefab;
    private float LastShoot;
    private int health;
    // Start is called before the first frame update
    void Start()
    {
        health=2;
    }

    // Update is called once per frame
    void Update()
    {
        if(John==null) return;
        Vector3 direction= John.transform.position-transform.position;
        if (direction.x>=0.0f)
        {
            transform.localScale=new Vector3(1.0f,1.0f,1.0f);
        }else{
            transform.localScale=new Vector3(-1.0f,1.0f,1.0f);

        }

        float distance= Mathf.Abs(John.transform.position.x-transform.position.x);

        if (distance<1.0f &&Time.time >LastShoot+1f)
        {
            Shoot();
            LastShoot=Time.time;
        }

    }
        private void Shoot(){
            // Debug.Log("Grunt disparando");
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

     public void OnBulletHit(){
        health-=1;
        if (health==0)
        {
            Destroy(gameObject);
        }
    }   
}
