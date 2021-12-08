using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubePlacement : MonoBehaviour
{
    private Grid grid;
    public bool building;
    public AudioSource plant;
    [SerializeField]
    public Transform floor;
    [SerializeField]
    public Transform cam;
    public Text guiText;

    public Transform Wall;
    public Transform Floor1;
    public Transform Stairs;

    public GameObject WallP;
    public GameObject FloorP;
    public GameObject StairP;

    public string what = "wall";

    RaycastHit Hit;

    private static Color white = new Color(255f/255f, 255f/255f, 255f/255f, 1f);
    private static Color black = new Color(0f/255f, 0f/255f, 0f/255f, 1f);
    private static Color brown = new Color(139f/255f, 69f/255f, 19f/255f, 1f);
    private static Color grey = new Color(128f/255f, 128f/255f, 128f/255f, 1f);
    private static Color red = new Color(255f/255f, 0f/255f, 0f/255f, 1f);
    private static Color orange = new Color(255f/255f, 128f/255f, 0f/255f, 1f);
    private static Color yellow = new Color(255f/255f, 255f/255f, 0f/255f, 1f);
    private static Color green = new Color(0f/255f, 255f/255f, 0f/255f, 1f);
    private static Color blue = new Color(0f/255f, 0f/255f, 255f/255f, 1f);
    private static Color purple = new Color(153f/255f, 51f/255f, 255f/255f, 1f);
    private static Color pink = new Color(255f/255f, 51f/255f, 255f/255f, 1f);


    private static Color[] colors = new Color[] {white,black,brown,red,orange,yellow,green,blue,purple,pink};
    private static string[] colorNames = new string[] {"White","Black","Brown","Red","Orange","Yellow","Green","Blue","Purple","Pink"};
    private int selectedColor = 0;

    private Vector3 position;

    private void Awake(){
        grid = FindObjectOfType<Grid>();
    }
    private void Update(){
        if (Input.GetKeyDown(KeyCode.B)){
            if(building == false){
                building = true;
            }else{
                building = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.N)){
            building = false;
        }
        if(building == false){
            floor.position = new Vector3(0,-2000f,0);
        }
        if(building == true){
            if(Physics.Raycast(cam.position,cam.forward,out Hit, 15f)){
            floor.position = new Vector3(Mathf.RoundToInt(Hit.point.x) != 0 ? Mathf.RoundToInt(Hit.point.x/5f) * 5f : 3f,
                (Mathf.RoundToInt(Hit.point.y) != 0 ? Mathf.RoundToInt(Hit.point.y/5f) * 5f : 0f) + floor.localScale.y,
                Mathf.RoundToInt(Hit.point.z) != 0 ? Mathf.RoundToInt(Hit.point.z/5f) * 5f : 3f);
                if (what == "wall"){
                    WallP.SetActive(true);
                    FloorP.SetActive(false);
                    StairP.SetActive(false);
                }
                if (what == "floor"){
                    WallP.SetActive(false);
                    FloorP.SetActive(true);
                    StairP.SetActive(false);
                }
                if (what == "stairs"){
                    WallP.SetActive(false);
                    FloorP.SetActive(false);
                    StairP.SetActive(true);
                }

                floor.eulerAngles = new Vector3(0,(Mathf.RoundToInt(cam.eulerAngles.y) != 0 ? Mathf.RoundToInt(cam.eulerAngles.y / 90f) * 90f : 0) + 90 ,0);
                guiText.text = " (Click to place, Right Click to change direction)";
            if(Input.GetMouseButtonDown(0)){
                if (what == "wall"){
                Instantiate(Wall,floor.position,floor.rotation);
                }
                if (what == "floor"){
                Instantiate(Floor1,floor.position,floor.rotation);
                }
                if (what == "stairs"){
                Instantiate(Stairs,floor.position,floor.rotation);
                }
                }
                if(Input.GetKeyDown(KeyCode.Z)){
                    what = "wall";
                }
                if(Input.GetKeyDown(KeyCode.X)){
                    what = "floor";
                }
                if(Input.GetKeyDown(KeyCode.C)){
                    what = "stairs";
                }
            }
        }else{
           
            
        }
    }
}
