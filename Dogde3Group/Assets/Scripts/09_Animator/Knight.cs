using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    [SerializeField] LayerMask m_layerMask;

    BoxCollider2D m_Collider;
    Animator m_Animator = null;
    bool m_isJump = false;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        CheckFloor();

        if ( Input.GetKeyDown( KeyCode.D ))
        {
            m_Animator.SetBool("isMove", true);
        }

        if( Input.GetKeyUp(KeyCode.D))
        {
            m_Animator.SetBool("isMove", false);
        }

        
        if( Input.GetKeyDown( KeyCode.Space ))
        {
            if (!m_isJump)
            {
                m_isJump = true;
                m_Animator.SetBool("isJump", true);

                Vector3 pos = transform.position;
                transform.position = new Vector3(pos.x, pos.y + 3.0f, pos.z);
            }
        }

        if( Input.GetMouseButtonDown(0))
        {
            m_Animator.SetTrigger("attack");
        }

    }

    public bool CheckFloor()
    {
        if (!m_isJump) return false;

        RaycastHit hit;
        
        if( Physics.Raycast(transform.position, -transform.up, out hit, 1000)) //    m_Collider.bounds.extents.y+0.2f)) //, m_layerMask))
        {
            if (hit.distance <= m_Collider.bounds.size.y + 0.1f)
            {
                m_Animator.SetBool("isJump", false);
                m_isJump = false;
                return true;
            }
        }

        Debug.DrawRay(transform.position, -transform.up, Color.red);

        return false;
    }





}
