using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject JohnPlayer;   
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(JohnPlayer!=null){
        Vector3 position= transform.position;
        position.x=JohnPlayer.transform.position.x;
        transform.position=position;

        }
    }
}
