using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_contro : MonoBehaviour
{
    private Transform player;
    private Animator anim;
    public float movespeed = 1.0f;
    private int horizontalID = Animator.StringToHash("Horizontal");
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            transform.position += transform.forward * Time.deltaTime * movespeed;
            anim.SetBool("IsMoveForward", true);
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            transform.position -= transform.forward * Time.deltaTime * movespeed;
            anim.SetBool("IsMoveBack", true);
        }
        anim.SetFloat("FBspeed", Input.GetAxis("Vertical"));
        anim.SetFloat("LRspeed", Input.GetAxis("Horizontal"));
        anim.SetBool("IsMoveForward", false);
        anim.SetBool("IsMoveBack", false);
        anim.SetBool("IsMoveL", false);
        anim.SetBool("IsMoveR", false);
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.position += transform.right * Time.deltaTime * movespeed;
            anim.SetBool("IsMoveR", true);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.position -= transform.right * Time.deltaTime * movespeed;
            anim.SetBool("IsMoveL", true);
        }
        player.Rotate(Vector3.up, Input.GetAxis("Mouse X"));
        player.Rotate(Vector3.down, Input.GetAxis("Mouse Y"));
    }
}
