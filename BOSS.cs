using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSS : MonoBehaviour
{

    public GameObject Player;
    public GameObject boss;
    //public LineRenderer laser;
    public GameObject Bullet;
    private float Timer = 0;
    public float RateTimeOfAOE = 1.0f;
    public Animator BossAnimatior;
    public float WalkSpeed = 0.5f;
    public float TrackDistance = 0.3f;
    private Coroutine AOE;
    bool iswalk = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            Player = other.gameObject;
            //LookAtYou();
            Debug.Log("Enter my area");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("player"))
        {
            Player = null;
            Debug.Log("Leave my area");
        }
    }

    // Use this for initialization
    void Start()
    {
        
       // BossAnimatior = gameObject.GetComponent<Animator>();
        //AOE = StartCoroutine(AOEAttack());
    }

    // Update is called once per frame
    void Update()
    {
        
        //MoveForYou();
        Attack();
    }

    private void MoveForYou()
    {
        
        Vector3 target = Player.transform.position;
        target.y = boss.transform.position.y;
        //boss.transform.Translate((boss.transform.position - target).normalized * Time.deltaTime * WalkSpeed);
        //boss.transform.position += boss.transform.right * WalkSpeed;
        //boss.transform.Translate(boss.transform.forward * Time.deltaTime * WalkSpeed);
        
    }

    private void LookAtYou()
    {
        Vector3 target = Player.transform.position;
        target.y = boss.transform.position.y;
        boss.transform.LookAt(target);
        Debug.Log("Look At your");
    }

    private void Attack()
    {
        StartCoroutine(AOEAttack());
        if (Player != null)
        {
            
            Vector3 distance = Player.transform.position - boss.transform.position;
            //获得主角和BOSS的距离
            if (distance.magnitude > TrackDistance)
            {
                BossAnimatior.SetBool("iswalking", false);
                transform.position += transform.forward * Time.deltaTime * WalkSpeed;
                BossAnimatior.SetBool("InMyArea", true);
                iswalk = true;
                BossAnimatior.SetBool("NearToMe", false);
                LookAtYou();
                MoveForYou();
                //当主角和敌人的距离还有一定距离的时候使用镭射攻击
                //LaserAttack();
            }
            else
            {
                //transform.position += transform.forward * Time.deltaTime * WalkSpeed;
                BossAnimatior.SetBool("iswalking", true);
                BossAnimatior.SetBool("InMyArea", false);
                BossAnimatior.SetBool("NearToMe", true);
                //当主角和敌人很接近的时候,BOSS会主动追击主角并使用近战技能
                LookAtYou();
                NearAttack();
            }
        }
        else
        {
            BossAnimatior.SetBool("iswalking", false);
            iswalk = true;
            //当主角在BOSS的攻击范围之外使用AOE范围攻击
            BossAnimatior.SetBool("InMyArea", false);
            BossAnimatior.SetBool("NearToMe", false);
        }
    }

    //private void LaserAttack()
    //{

    //    Debug.Log("Laser Attack");
    //}

    private void NearAttack()
    {
       // laser.enabled = false;
        BossAnimatior.SetBool("NearToMe", true);
        Debug.Log("Near Attack");
    }

    IEnumerator AOEAttack()
    {
        BossAnimatior.SetBool("NearToMe", false);
        Debug.Log("AOE Attack");
        int BulletNum = 10;
        if (CountTime(RateTimeOfAOE) == true)
        {
            for (int i = 0; i < BulletNum; i++)
            {
                GameObject.Instantiate(Bullet, transform.position, Quaternion.Euler(0, i * (360 / BulletNum), 0));
            }
            yield return new WaitForSeconds(5.0f);
        }
    }

    private bool CountTime(float RateTime)
    {
        //Debug.Log("Timer" + Timer);
        if (Timer > RateTime)
        {
            Timer -= RateTime;
            return true;
        }
        else
        {
            Timer += Time.deltaTime;
            return false;
        }

    }

}