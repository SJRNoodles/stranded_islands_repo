using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyTool : MonoBehaviour
{
    public bool destroying = false;
    public AudioSource destroySound;
    public ParticleSystem DestructionEffect;
    public Text guiText;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B)){
            destroying=false;
        }
        if (Input.GetKeyDown(KeyCode.N)){
            if(destroying == false){
                destroying=true;
                guiText.text = " -Destroying -";
            }else{
                destroying=false;
                guiText.text = "Press B to build and N to destroy";
            }
        }
        if (Input.GetMouseButtonDown(0)) 
        {
            if(destroying==true){
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                
                if(Physics.Raycast(ray, out hit))
                {
                    if(hit.collider!=null){
                        if(hit.collider.gameObject.tag != "Ground"){
                            ParticleSystem explosionEffect = Instantiate(DestructionEffect);
                            explosionEffect.transform.position = hit.collider.gameObject.transform.position;
                            explosionEffect.Play();

                            destroySound.Play();
                            Destroy(hit.collider.gameObject);
                            Destroy(explosionEffect.gameObject, explosionEffect.duration);
                        }
                    }
                }
            }
        }
    }
}
