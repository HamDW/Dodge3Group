using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * 
 * 
 *  Animator BlendTree 연습
 * 
 * 
 */

public class Knight2 : MonoBehaviour
{
    Animator m_Animator = null;
    bool m_isJump = false;
    bool m_isWalk = false;

    [SerializeField] Transform m_Body = null;
    public float m_Speed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
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

    // Animator Blend Tree를 이용한 이동
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

            // 주의 : 2D일때만 사용하자
            #region  
            if (xDir < 0)
                m_Body.eulerAngles = new Vector3(0, 180, 0);   // 좌우 회전 시켜준다.( 2D 캐릭터 이므로 )
            else
                m_Body.eulerAngles = Vector3.zero;
            #endregion
        }
        m_Animator.SetBool("IsWalk", m_isWalk);
        m_Animator.SetFloat("dirX", vDir.x);
        m_Animator.SetFloat("dirZ", vDir.z);
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
