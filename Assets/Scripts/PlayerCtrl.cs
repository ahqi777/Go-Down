using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    float xvelocity;
    public float speed,jumpforce,fanforce;
    public  bool isonground;
    public float checkradius;
    public LayerMask ground;
    public GameObject groundcheck,protect;
    public bool dead,inprotect;
    public AudioSource jumpmusic,bgm;
    public AudioSource deadmusic;
    public Joystick joystick;
    public RoleInfo roleInfo;
   
    void Start()
    {        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        roleInfo = Resources.Load<RoleInfo>("RoleInfo/" + this.gameObject.name);
        speed = roleInfo.MoveSpeed;
        jumpforce = roleInfo.JumpSpeed;
        fanforce = 100 / roleInfo.Weight;
    }
   
   
    void Update()
    {
        isonground = Physics2D.OverlapCircle(groundcheck.transform.position, checkradius, ground);//確認在地面
        anim.SetBool("fall", !isonground);
        movement();
        fall();
    }
    
   
    void movement()//玩家移動
    {
        
        anim.SetFloat("speed",Mathf.Abs(rb.velocity.x));
        xvelocity = joystick.Horizontal;
        rb.velocity = new Vector2(xvelocity * speed, rb.velocity.y);
        if (xvelocity != 0)
        {
            transform.localScale =new Vector3(xvelocity, 1, 1);
        }
        if (this.transform.position.x > 4.2f)
        {
            this.transform.position = new Vector3(-4.2f, this.transform.position.y, this.transform.position.z);
        }
        else if (this.transform.position.x < -4.2f)
        {
            this.transform.position = new Vector3(4.2f, this.transform.position.y, this.transform.position.z);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)//碰撞尖刺死亡
    {
        if (other.CompareTag("spike"))
        {
            if (inprotect == true)
            {
                anim.Play("pinkman_protect");
            }
            else
            {
                deadmusic.Play();
                GetComponent<Collider2D>().enabled = false;
                anim.SetTrigger("dead");
            }
        }
        if (other.CompareTag("lowspike"))//掉下去死亡
        {
                deadmusic.Play();
                GetComponent<Collider2D>().enabled = false;
                anim.SetTrigger("dead");
        }

    }
    public void deadcheck()//確認死亡
    {
        if (inprotect == true)
        {
            dead = false;
        }
        dead = true;
        GameManager.Gameover(dead);
    }
    public void destroy()//摧毀玩家 
    {
        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("jumpplatform"))
        {
            jumpmusic.Play();
            anim.SetBool("jump",true);
            rb.velocity = new Vector2(rb.velocity.x,jumpforce/1.2f);
            
        }
        if (other.gameObject.CompareTag("fan"))
        {
            jumpmusic.Play();
            anim.SetBool("jump", true);
            rb.velocity = new Vector2(rb.velocity.x, fanforce);

        }
    }
   public void ninjafrogskill()//青蛙技能
    {
        jumpmusic.Play();
        anim.SetBool("skill", true);
        rb.velocity = new Vector2(rb.velocity.x, jumpforce/1.2f);
    }
    public void maskmanskill()//面具男技能
    {
        anim.SetBool("skill", true);
    }
    
    public void maskskillover()//面具男技能動畫結束
    {
        anim.SetBool("skill",false);
    }
    public void pinkmanskill()//粉紅男技能
    {
        protect.SetActive(true);//防護罩開啟
        inprotect = true;//保護中
        anim.SetBool("skill", true); 
    }
    public void pinkmanskillover()//粉紅男施放技能動畫結束
    {
        anim.SetBool("skill", false);
    }
    public void pinkmanskillov()//粉紅男護罩沒了
    {
        anim.SetBool("protect", false);
        Invoke("pink", 2f);//無敵2秒
    }
    public void pink()//不在保護中
    {
        inprotect = false;
    }
    public void guyskill()//guy技能
    {
        anim.SetBool("skill", true);
    }
    public void guykillover()//guy技能動畫結束
    {
        anim.SetBool("skill", false);
    }
    public void guykillstart()//guy技能開始
    {
        speed = 10;
    }
    public void guykillov()//guy技能結束
    {
        speed = 5;
    }

    void fall()//跳躍轉落下動畫
    {
        if (anim.GetBool("jump"))
        {
            if (rb.velocity.y < 0)
            {
                anim.SetBool("jump", false);
                anim.SetBool("fall", true);
            }
        }
        if (anim.GetBool("skill"))
        {
            if (rb.velocity.y < 0)
            {
                anim.SetBool("skill", false);
                anim.SetBool("fall", true);
            }
        }
    }
   public void audiostop()//音樂暫停
    {
        bgm.Pause();
        
    }
    public void audiostart()//音樂開始
    {
        bgm.Play();     
    }
}
