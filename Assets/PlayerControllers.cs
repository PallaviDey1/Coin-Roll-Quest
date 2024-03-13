using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerControllers : MonoBehaviour
{
    public float speed;
    public Text countText;
    private Rigidbody rb;
    private int count;
    public Text timer;
    public Text timeOut;
    public float timeRemaining = 30.0f;
    

    void Start()
    {
       rb = GetComponent<Rigidbody>();
       
       count = 0;
       SetCountText();
    }

    
    void FixedUpdate()
    {
       float moveHorizontal = Input.GetAxis("Horizontal");
       float moveVertical = Input.GetAxis("Vertical");
       Vector3 movement = new Vector3(moveHorizontal,0.0f,moveVertical);
       rb.AddForce (movement*speed);
       timeRemaining -=Time.deltaTime;
       timer.text=(timeRemaining).ToString("0");
       if(timeRemaining<0)
       {
        timeOut.text=("Time is running out ");
       }
    }
    void OnTriggerEnter(Collider other)
    {
      if(other.gameObject.CompareTag("Pick Up"))
      {
         other.gameObject.SetActive(false);
         count = count + 1;
        SetCountText();
      }
    }
    void SetCountText()
    {
      countText.text = "Score: " + count.ToString();

    }
    
}
