using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_attack02 : MonoBehaviour
{
    private Transform player;
    private Animator anim;
    public float movespeed = 1.0f;
    bool iswalking = true;
    private float time = 0;
    // Start is called before the first frame update

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("shot"))
        {
            anim.SetBool("was_hit", true);
            Destroy(other, 3.0f);
        }
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (iswalking)
        {
            anim.SetBool("iswaking", false);
        }
        anim.SetBool("iswaking", true);
        if(Time.time-time>10.0f)
        {
            anim.SetBool("player_exist", false);
            time = Time.time;
        }
        if (Time.time - time > 4.0f)
        {
            anim.SetBool("player_exist", true);
        }
    }
}
