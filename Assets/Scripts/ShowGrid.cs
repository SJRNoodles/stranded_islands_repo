using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGrid : MonoBehaviour
{
    public Transform tf;
    public Transform playerTransform;
    public AudioSource clickNoise;
    public float gridSize = 2;
    public bool building;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N)){
            building=false;
        }
        if (Input.GetKeyDown(KeyCode.B)){
            if(building == false){
                building=true;
            }else{
                building=false;
            }
        }

        if(building == true){
            transform.position = new Vector3(playerTransform.position.x,-2.5f + (tf.position.y-5),playerTransform.position.z);
            if (Input.GetKeyDown(KeyCode.Equals)){
                tf.position = new Vector3(tf.position.x,tf.position.y+gridSize,tf.position.z);
                clickNoise.Play();
            }
            if (Input.GetKeyDown(KeyCode.Minus)){
                tf.position = new Vector3(tf.position.x,tf.position.y-gridSize,tf.position.z);
                clickNoise.Play();
            }
        }else{
          transform.position = new Vector3(playerTransform.position.x,-99999f,playerTransform.position.z);  
        }
    }
}
