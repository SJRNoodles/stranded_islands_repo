using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float sens = 3;
    public float movementSpeed = 15;
    public float jumpHeight = 32;
    public Rigidbody rb;
    public Transform camera;
    public GameObject cameraItself;
    public AudioSource jumpSound;
    public float plrSize = 4.5f;

    private bool canJump = false;
    public bool firstPerson = false;
    public Animator anim;
    public GameObject gfx;

    void Start(){
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        transform.localEulerAngles += new Vector3(0,Input.GetAxis("Mouse X") * sens,0);
        cameraItself.transform.localEulerAngles += new Vector3(Input.GetAxis("Mouse Y") * sens,0,0);

        if(firstPerson==true){
            camera.transform.position = cameraItself.transform.position;
            gfx.SetActive(false);
        }else{
            camera.transform.localPosition = new Vector3(1f,0f,-5f);
            gfx.SetActive(true);
        }

        rb.AddForce(new Vector3 (Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z).normalized * Input.GetAxis("Vertical") *  movementSpeed * Time.deltaTime, ForceMode.Impulse);
        rb.AddForce(new Vector3 (Camera.main.transform.right.x, 0, Camera.main.transform.right.z).normalized * Input.GetAxis("Horizontal") *  movementSpeed * Time.deltaTime, ForceMode.Impulse);
        
        if(Mathf.Abs(Input.GetAxis("Vertical")) > 0 || Mathf.Abs(Input.GetAxis("Horizontal")) > 0){
            anim.SetBool("isRunning",true);
        }else{
            anim.SetBool("isRunning",false);
        }

        RaycastHit hit;
        Ray landingRay = new Ray(transform.position, Vector3.down);
        Debug.DrawRay(transform.position, Vector3.down * plrSize);
 
        if (Physics.Raycast(landingRay, out hit, plrSize))
        {
            if (hit.collider == null){
                canJump=false;
            }else{
                canJump=true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Tab)){
            if(firstPerson==false){
                firstPerson=true;
            }else{
                firstPerson=false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space)){
            if(canJump){
                rb.AddForce(0, jumpHeight, 0, ForceMode.Impulse);
                canJump=false;
                jumpSound.Play();
            }
        }
    }
}
