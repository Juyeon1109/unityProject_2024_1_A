using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExcubePlayer : MonoBehaviour
{
    public Rigidbody m_Rigidbody;
    public int Force = 100;
    public float checkTime = 0;
    public Text m_Text;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))        //스페이스를 누를 때 조건
        {
            m_Rigidbody.AddForce(transform.up * Force);
        }

        checkTime += Time.deltaTime;
        if(checkTime >= 1.0f)
        {
            Point



