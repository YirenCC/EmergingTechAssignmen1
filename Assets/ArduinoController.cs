using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class ArduinoController : MonoBehaviour
{
    SerialPort serial = new SerialPort("COM4", 9600);

    public int value = 0;

    Rigidbody m_Rigidbody;
    public float gravity;
    public float speed;
    bool m_Grounded;
    public float m_MaxSpeed;
    public float jumpSpeed;

    // Use this for initialization
    void Start()
    {
        serial.Open();
        m_Rigidbody = gameObject.GetComponent<Rigidbody>();
        m_Grounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        string buttonS = serial.ReadLine();
        value = int.Parse(buttonS);
        if ((value == 1) && m_Grounded)
        {
            m_Rigidbody.velocity += transform.up * jumpSpeed * Time.deltaTime;
            m_Grounded = false;
        }
        if ((value == 2) && m_Grounded == false)
        {
            m_Rigidbody.velocity -= transform.up * jumpSpeed * Time.deltaTime;
            m_Grounded = true;
        }
        if ((value == 3))
        {
            m_Rigidbody.velocity += transform.forward * Time.deltaTime * speed;
            float l_y = m_Rigidbody.velocity.y;
            m_Rigidbody.velocity = Vector3.ClampMagnitude(m_Rigidbody.velocity, m_MaxSpeed);
            m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x, l_y, m_Rigidbody.velocity.z);
        }
        if ((value == 4))
        {
            m_Rigidbody.velocity += -transform.forward * Time.deltaTime * speed;
            float l_y = m_Rigidbody.velocity.y;
            m_Rigidbody.velocity = Vector3.ClampMagnitude(m_Rigidbody.velocity, m_MaxSpeed);
            m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x, l_y, m_Rigidbody.velocity.z);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts.Length > 0)
        {
            Debug.Log("Collision");
            if (Vector3.Dot(transform.up, collision.contacts[0].normal) > 0.5f)
            {
                Debug.Log("Grounded");
                m_Grounded = true;
            }
        }
    }

}

