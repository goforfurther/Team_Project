using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class state_contro : MonoBehaviour
{
    public float health;
    private float current_health;
    public float pro ;
    private float current_pro;
    public float magi;
    private float current_magi;
    public Slider slider_life;
    public Slider slider_pro;
    public Slider slider_magi;
    public float damage = 0;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("sword"))
        {
            damage= Random.Range(5.0f, 15.0f);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        current_health = health;
        current_pro = pro;
        current_magi = magi;
    }

    // Update is called once per frame
    void Update()
    {
        if(current_pro<=0)current_health -= damage;
        current_pro -= damage;
        damage = 0;
        slider_life.value = current_health * 1.0f / health;
        slider_pro.value = current_pro * 1.0f / pro;
        slider_magi.value = current_magi * 1.0f / magi;
    }
}
