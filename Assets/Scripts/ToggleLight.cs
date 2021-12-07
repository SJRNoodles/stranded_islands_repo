using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLight : MonoBehaviour
{
    public Light flash;
    public AudioSource sound;
    private bool light = false;

    void Update()
    {
        flash.enabled = light;
        if (Input.GetKeyDown(KeyCode.G)){
            sound.Play();
            if(light == false){
                light=true;
            }else{
                light=false;
            }
        }
    }
}
