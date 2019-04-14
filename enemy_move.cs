using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class enemy_move : MonoBehaviour
{
    private Animator anim;
    public Transform enem01;
    private Transform[] wayPoints;
    private int index = 0;
    public float speed = 1.0f;
    public float totalHp = 150.0f;
    public float Hp = 150.0f;
    public Slider HpSlider;
    private bool was_hit = false;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("shot"))
        {
            //TakeDamage(Random.Range(10.0f, 20.0f));
            was_hit=true;
        }
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        enem01.position = new Vector3(Random.Range(-10.0f, -12.0f), 0.2f, Random.Range(23.0f, 26.5f));
        //enem01.position.x = Random.Range(-10.0f,-12.0f);
        //enem01.position.z = Random.Range(23.0f, 26.5f);
        wayPoints = wayRoom1.positions;
        index = Random.Range(0, wayPoints.Length);
        Hp = totalHp;
        HpSlider = GetComponentInChildren<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        //enem01.position = new Vector3(Random.Range(-10.0f, -12.0f), 0.2f, Random.Range(23.0f, 26.5f));
        Move();
        if(was_hit)
        {
            float Damage = Random.Range(10.0f, 20.0f);
            if (Hp <= 0)
            {
                anim.SetBool("isdead", true);//died;
            }
            else
            {
                Hp -= Damage;
            }
            was_hit = false;
        }
        HpSlider.value = Hp / totalHp;
    }

    private void Move()
    {
        transform.Translate((wayPoints[index].position - transform.position).normalized * Time.deltaTime * speed);
        if (Vector3.Distance(wayPoints[index].position, transform.position) < 0.2f)
        {
            index = Random.Range(0, wayPoints.Length );
        }
    }

    //public void TakeDamage(float Damage)
    //{
    //    if (Hp <= 0)
    //    {
    //       //died;
    //    }
    //    else
    //    {
    //        Hp -= Damage;
    //    }
    //}

     
}
