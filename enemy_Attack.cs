using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_Attack : MonoBehaviour
{
    public Transform shotspawn;
    public GameObject shot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject go = GameObject.Instantiate(shot, shotspawn.position, shotspawn.rotation) as GameObject;
        GameObject.Destroy(go, 3f);
    }
}
