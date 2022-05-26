using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum AnimationClip
{
    jump,
    fall,
    skill,
}

public class PlayerCtrl : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    float xvelocity;
    public float speed,jumpforce,fanforce;
    public float checkradius;
    public LayerMask ground;
    public GameObject groundcheck, shield, skilleffect;
    public bool dead, inprotect, isonground;
    public AudioSource jumpmusic;
    public AudioSource deadmusic;
    public Joystick joystick;
    public RoleInfo roleInfo;
    public string[] clips;
    /// <summary>
    /// 初始化參數
    /// </summary>
    void Awake()
    {        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        roleInfo = Resources.LoadAll<RoleInfo>("RoleInfo")[ChoiceManager.currindex];
        anim.runtimeAnimatorController = roleInfo.animatorctrl;
        speed = roleInfo.MoveSpeed;
        jumpforce = roleInfo.JumpSpeed;
        fanforce = 100 / roleInfo.Weight;
    }
    void FixedUpdate()
    {
        isonground = Physics2D.OverlapCircle(groundcheck.transform.position, checkradius, ground);//確認在地面
        anim.SetBool("fall", !isonground);
        Movement();
        Fall();
    }
    /// <summary>
    /// 玩家移動
    /// </summary>
    private void Movement()
    {
        if (isonground == true)
            anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));
        else
            anim.SetFloat("speed", 0);

        xvelocity = joystick.Horizontal;
        rb.velocity = new Vector2(xvelocity * speed, rb.velocity.y);
        if (xvelocity != 0)
        {
            transform.localScale = new Vector3(xvelocity, 1, 1);
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
    /// <summary>
    /// 判斷碰撞尖刺死亡
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
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
    /// <summary>
    /// 碰到彈跳平台
    /// </summary>
    /// <param name="other"></param>
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("fan"))
        {
            jumpmusic.Play();
            anim.SetBool("jump", true);
            rb.velocity = new Vector2(rb.velocity.x, fanforce);

        }
        if (other.gameObject.CompareTag("jumpplatform"))
        {
            jumpmusic.Play();
            other.gameObject.GetComponent<Animator>().Play("jump");
            Destroy(other.gameObject, 0.25f);
            anim.SetBool("jump", true);
            rb.velocity = new Vector2(rb.velocity.x, jumpforce / 1.2f);

        }
    }
    /// <summary>
    /// 確認死亡
    /// </summary>
    public void Deadcheck()
    {
        if (inprotect == true)
        {
            dead = false;
        }
        dead = true;
        Destroy(gameObject);
        GameManager.instance.Gameover(dead);
    }
    /// <summary>
    /// 發動技能
    /// </summary>
    public void Skill()
    {
        PlayAnim(AnimationClip.skill);
        skilleffect.SetActive(true);
        switch (roleInfo.roleName)
        {
            case "忍者蛙蛙":
                jumpmusic.Play();
                rb.velocity = new Vector2(rb.velocity.x, jumpforce / 1.2f);
                Invoke("SkillOver", 1f);
                break;
            case "時間面具":
                Time.timeScale = 0.5f;
                Invoke("SkillOver", 5f);
                break;
            case "藍速":
                speed = speed * 2;
                Invoke("SkillOver", 5f);
                break;
            case "麻吉麻":
                shield.SetActive(true);//防護罩開啟
                inprotect = true;//保護中
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// 播放動畫
    /// </summary>
    /// <param name="clip"></param>
    public void PlayAnim(AnimationClip clip)
    {
        ResetAnimState();
        anim.SetBool(clip.ToString(), true);
    }
    /// <summary>
    /// 重置動畫狀態
    /// </summary>
    public void ResetAnimState()
    {
        for (int i = 0; i < clips.Length; i++)
        {
            anim.SetBool(clips[i], false);
        }
        anim.SetFloat("speed", 0);
    }
    /// <summary>
    /// 技能效果結束
    /// </summary>
    public void SkillOver()
    {
        Time.timeScale = 1f;//重置時間面具的技能
        speed = roleInfo.MoveSpeed;//重置藍速的技能
        inprotect = false;//重置麻吉麻的技能
        skilleffect.SetActive(false);
    }
    /// <summary>
    /// 播放技能動畫結束
    /// </summary>
    public void SkillAnimOver()
    {
        anim.SetBool("skill", false);
    }
    /// <summary>
    /// //護罩沒了
    /// </summary>
    public void PinkmanSkillOver()
    {
        anim.SetBool("protect", false);
        Invoke("SkillOver", 2f);//無敵2秒
    }
    /// <summary>
    /// //跳躍動畫轉落下動畫
    /// </summary>
    void Fall()
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
}
