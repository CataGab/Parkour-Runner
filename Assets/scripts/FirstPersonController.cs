using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FirstPersonController : MonoBehaviour
{   bool restart = false;
    Scene scene;
    private float delayBeforeLoading = 1f;
    public Camera cam1;
    public Camera cam2;
    public float movementSpeed = 5.0f;
    public float mouseSensitivity = 5.0f;
    float verticalRotation = 0;
    public float upDownRange = 60.0f;
    public int score;
    public float jumpSpeed = 1;
    float verticalVelocity = 0;
    public Text scoreText;
    public GameObject[] pickups;
    private int numPickups = 4;
    public Text winText;
    public Text restartText;
    public Text loseText;
    public Text pauseText;
    public Text dEasyText;
    public Text dHardText;
    private float timeElapsed;

    // Use this for initialization
    void Start()
    {
        cam1.enabled = true;
        cam2.enabled = false;
        pickups = GameObject.FindGameObjectsWithTag("PickUp");
        Screen.lockCursor = true;
        score = 0;
        winText.text = "";
        SetCountText();
    }

    //getting killed by lava
   

    //Collecting coins and displaying score for that
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Floor") {
            //loseText.text = "YOU DEAD BOY!";
            //restartText.text = "Press 'R' for Restart";
            //restart = true;
            //GameObject.Destroy(gameObject);
            
                if (scene.name == "Level1")
                {
                    SceneManager.LoadScene("Level1");
                }
                else
                {
                    SceneManager.LoadScene("Level2");
                }
            

        }

        if (other.gameObject.tag == "PickUp")
        {
           
            AudioSource audio = other.gameObject.GetComponent<AudioSource>();
            audio.Play();
            other.gameObject.SetActive(false);
            score = score + 100 ;
            
        }

        if (other.gameObject.tag == "Win") {
            winText.text = "YOU WON!";
            
            if (scene.name == "Level1")
            {
                SceneManager.LoadScene("Level2");
            }
            else
            {
                Screen.lockCursor = false;
                SceneManager.LoadScene("Menu");
            }

        }
    }

    public void SetCountText()
    {

        scoreText.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        /* if (Input.GetKeyDown(KeyCode.R) && restart == true){
             restart = false;
             if (scene.name == "Level1")
             {
                 SceneManager.LoadScene("Level1");
             }
             else
             {
                 SceneManager.LoadScene("Level2");
             }
             }*/
        //camera switch
    
            if (Input.GetKeyDown(KeyCode.V))
        {
            if (cam1.enabled == true)
            {
                cam1.enabled = false;
                cam2.enabled = true;
            }
            else if (cam2.enabled == true)
            {
                cam1.enabled = true;
                cam2.enabled = false;
            }


        }
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Screen.lockCursor = false;
            SceneManager.LoadScene("Menu");
        }
        if (Input.GetKeyDown(KeyCode.P)) {
            if (Time.timeScale == 0)
            {
                loseText.text = "";
                Time.timeScale = 1;
            }
            else
            {
                loseText.text = "Press P to resume the game!";
                Time.timeScale = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.H)) {
            dEasyText.text = "";
            dHardText.text = "Hard Mode";
            jumpSpeed = 7.0f;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            dHardText.text = "";
            dEasyText.text = "Easy Mode";
            jumpSpeed = 10.0f;
        }
        //UpdatePlayerInfo();

        CharacterController cc = GetComponent<CharacterController>();
        SetCountText();
        float rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, rotLeftRight, 0);
        verticalRotation = verticalRotation - Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        //Movement


        float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
        float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;

        verticalVelocity = verticalVelocity + Physics.gravity.y * Time.deltaTime;

        if (cc.isGrounded && Input.GetButton("Jump"))
        {
            verticalVelocity = jumpSpeed;
        }



        Vector3 speed = new Vector3(sideSpeed, verticalVelocity, forwardSpeed);

        speed = transform.rotation * speed;


        cc.Move(speed * Time.deltaTime);

        scene = SceneManager.GetActiveScene();
        

    }
}

// I was inspired from the labs, lectures and the tutorial of this guy: https://www.youtube.com/watch?v=rhpJPx8fICQ
