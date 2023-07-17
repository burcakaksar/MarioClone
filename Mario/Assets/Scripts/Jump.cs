using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour

{
    Rigidbody2D rb;
    [SerializeField] Transform feetPos; 
    [SerializeField] LayerMask layermask;//playerýn zeminde olduðunu göremk için

    [SerializeField] public float jumpAmount;// zýplama miktarýný vermek için kullandýk.
    [SerializeField] float radius;// zýplarken alacaðo radius deðeri vermek için kullandýk.
    [SerializeField] float startJumpTime;
    [SerializeField] public Animator animSmall;
    [SerializeField] public Animator animBig;

    public float fallGravityScale;//düþerken alacaðý yerçekimi
    public float gravityScale;//  zýplarken alacaðý yerçekimi
    
    float jumpTime;
    public bool isJumping;// basýlý tuttuðu  zaman zýplamasý için  

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    private void Update()
    {
        Jumping();// Jump metodunu çaðýrdýk.
        IsGrounded();
        Gravity();
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(feetPos.position, radius, layermask);
    }

    private void Jumping()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded() && LevelManager.canMove) //*can move Level managerden gelmsesi gerekli
        {

            isJumping = true; // karaktere Ölçülü Zýplama mekaniði ekledik.
            jumpTime = startJumpTime;// ne kadar süre havada kalmasý için zaman deðeri verdik.
            rb.AddForce((Vector2.up * jumpAmount) / 2, ForceMode2D.Impulse);//zýplamanýn kuvveti ve ilk baþta alacaðý güç içİN kullandýk.  
            SoundManager.instance.PlayWithIndex(10);
            animSmall.SetBool("Jump", true);
            animBig.SetBool("Jump", true);
        }

        if (Input.GetButton("Jump") && isJumping)
        {
            if (jumpTime > 0)
            {
                rb.AddForce(Vector2.up * 8, ForceMode2D.Force);
                jumpTime -= Time.deltaTime;
            }
            
        }
        if (Mathf.Approximately(rb.velocity.y, 0) && animSmall.GetBool("Jump"))
        {
            animSmall.SetBool("Jump", false);
        }
        if (Mathf.Approximately(rb.velocity.y, 0) && animBig.GetBool("Jump"))
        {
            animBig.SetBool("Jump", false);
        }
    }

    private void Gravity()// yerçekimini ayarlamak için kullandýk
    {
        if (rb.velocity.y >= 0)
        {
            rb.gravityScale = gravityScale;
        }
        else if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallGravityScale;
        }
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(feetPos.position,radius);
    //}
}
