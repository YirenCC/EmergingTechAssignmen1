using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour {
    Rigidbody m_Rigidbody;
    public float gravity;
    public float speed;
    public float m_MaxSpeed;
    // Use this for initialization
    void Start () {
        m_Rigidbody = gameObject.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (gameObject.GetComponent<ArduinoController>().a == true)
        {
            m_Rigidbody.velocity += transform.forward * Time.deltaTime * speed;
            float l_y = m_Rigidbody.velocity.y;
            m_Rigidbody.velocity = Vector3.ClampMagnitude(m_Rigidbody.velocity, m_MaxSpeed);
            m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x, l_y, m_Rigidbody.velocity.z);
        }
        if (gameObject.GetComponent<ArduinoController>().b == true)
        {
            m_Rigidbody.velocity += -transform.forward * Time.deltaTime * speed;
            float l_y = m_Rigidbody.velocity.y;
            m_Rigidbody.velocity = Vector3.ClampMagnitude(m_Rigidbody.velocity, m_MaxSpeed);
            m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x, l_y, m_Rigidbody.velocity.z);
        }
        if (gameObject.GetComponent<ArduinoController>().c == true)
        {
            m_Rigidbody.velocity += transform.forward * Time.deltaTime * speed;
            float l_y = m_Rigidbody.velocity.y;
            m_Rigidbody.velocity = Vector3.ClampMagnitude(m_Rigidbody.velocity, m_MaxSpeed);
            m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x, l_y, m_Rigidbody.velocity.z);
        }
        if (gameObject.GetComponent<ArduinoController>().d == true)
        {
            m_Rigidbody.velocity += -transform.forward * Time.deltaTime * speed;
            float l_y = m_Rigidbody.velocity.y;
            m_Rigidbody.velocity = Vector3.ClampMagnitude(m_Rigidbody.velocity, m_MaxSpeed);
            m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x, l_y, m_Rigidbody.velocity.z);
        }
    }
}
