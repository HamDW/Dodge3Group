using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight2 : MonoBehaviour
{
    Animator m_Animator = null;
    bool m_isJump = false;
    bool m_isWalk = false;

    public float m_Speed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //if( Input.GetKeyDown(KeyCode.D))
        //{
        //    m_Animator.SetBool("IsWalk", true);
        //    m_isWalk = true;
        //}

        //if (Input.GetKeyUp(KeyCode.D))
        //{
        //    m_Animator.SetBool("IsWalk", false);
        //    m_isWalk = false;
        //}

        Update_Move();


        if( Input.GetKey(KeyCode.Space) && !m_isJump )
        {
            m_isJump = true;
            m_Animator.SetBool("IsJump", true);

            Vector3 vPos = transform.position;
            vPos.y += 2.5f;
            transform.position = vPos;
        }

        if( Input.GetMouseButtonDown(0))
        {
            m_Animator.SetTrigger("attack");
        }

    }

    public void Update_Move()
    {
        float xDir = Input.GetAxisRaw("Horizontal");
        float zDir = Input.GetAxisRaw("Vertical");

        Vector3 vDir = new Vector3(xDir, 0, zDir);
        m_isWalk = false;
        if ( vDir != Vector3.zero)
        {
            m_isWalk = true;
            transform.Translate(vDir.normalized * m_Speed * Time.deltaTime);
        }
        m_Animator.SetBool("IsWalk", m_isWalk);
        m_Animator.SetFloat("DirX", vDir.x);
        m_Animator.SetFloat("DirZ", vDir.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if( collision.gameObject.tag == "Floor")
        {
            m_isJump = false;
            m_Animator.SetBool("IsJump", false);
            Debug.Log(" Floor 충돌 ");
        }
    }

}
