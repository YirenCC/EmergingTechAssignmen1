using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.IO.Ports;

public class ArduinoController : MonoBehaviour
{
    SerialPort serial = new SerialPort("COM4", 9600);

    public bool a, b, c, d = false;

    // Use this for initialization
    void Start()
    {
        serial.Open();

        StartCoroutine
    (
    AsynchronousReadFromArduino
    ((string s) => inputCallback(s),     // Callback
        () => Debug.LogError("Error!"), // Error callback
        10000f                          // Timeout (milliseconds)
    )
    );
    }


    void inputCallback(string s)
    {
        if (s == "1")
        {
            a = true;
        }
        if (s == "2")
        {
            b = true;
        }
        if (s == "3")
        {
            c = true;
        }
        if (s == "4")
        {
            d = true;
        }
        if (s == "9")
        {
            a = false;
            b = false;
            c = false;
            d = false;
        }

    }
    // Update is called once per frame
    /*void Update()
    {

        return;    
    }*/

    public IEnumerator AsynchronousReadFromArduino(Action<string> callback, Action fail = null, float timeout = float.PositiveInfinity)
    {
        DateTime initialTime = DateTime.Now;
        DateTime nowTime;
        TimeSpan diff = default(TimeSpan);

        string dataString = null;

        do
        {
            try
            {
                dataString = serial.ReadLine();
            }
            catch (TimeoutException)
            {
                dataString = null;
            }

            if (dataString != null)
            {
                callback(dataString);
                yield return null;
            }
            else
                yield return new WaitForSeconds(0.05f);

            nowTime = DateTime.Now;
            diff = nowTime - initialTime;

        } while (diff.Milliseconds < timeout);

        if (fail != null)
            fail();
        yield return null;
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts.Length > 0)
        {
            Debug.Log("Collision");
            if (Vector3.Dot(transform.up, collision.contacts[0].normal) > 0.5f)
            {
                Debug.Log("Grounded");
            }
        }
    }
    
}

