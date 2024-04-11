using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExcubePlayer : MonoBehaviour
{
    public Text TextUI = null;          // 텍스트 UI
    public int Count = 0;               // 마우스 클릭 카운터
    public float Power = 100;           // 물리 힘 수치
   
    public int Point = 0;
    public float checkTime = 0.0f;
    public float checkEndTime = 30.0f;

    public Rigidbody m_Rigidbody;       // 오브젝트의 강체

    // Update is called once per frame
    void Update()
    {
        checkEndTime -= Time.deltaTime;

        if (checkEndTime <= 0)
        {
            PlayerPrefs.SetInt("Point", Point);
            SceneManager.LoadScene("ResultScene");
        }


        checkTime += Time.deltaTime;
        if(checkTime >= 1.0f)
        {
            Point += 1;
            checkTime = 0.0f;
        }


        if (Input.GetKeyDown(KeyCode.Space))        //스페이스를 누를 땐
        {
            Count += 1;                             //마우스가 클릭되었을때 Count를 1씩 올린다
            TextUI.text = Count.ToString();         //UI 갱신
            Power = Random.Range(100, 200);         //100 ~ 200 사이의 값의 힘을 준다.
            m_Rigidbody.AddForce(transform.up * Power);     //Y축으로 설정한 힘을 준다.
        }

        TextUI.text = Point.ToString();

      
    }
    void OnCollisionEnter(Collision collision)      //충돌이 되었을 때
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Pipe")
        {
            Point = 0;
            gameObject.transform.position = Vector3.zero;       //플레이어를 원점으로 이동 시킨다.
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Items")
        {
            Point += 10;
            Destroy(other.gameObject);
        }
    }

}

