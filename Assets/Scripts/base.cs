using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    private float fWaitTime = 999999.9f;
    private float fCurrentTime = 999999.9f;
    private bool bFinished = false;
    private bool bActive = false;

    ~Timer()
    {
        //Debug.Log("Timer被回收了！");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (bActive == true)
        {
            if (bFinished == false)
            {
                fCurrentTime -= Time.deltaTime;
                //Debug.Log($"fCurrentTime：{fCurrentTime}");
                if (fCurrentTime <= 0.0f)
                {
                    fCurrentTime = fWaitTime;
                    bFinished = true;
                }
            }
           
        }
    }

    public void SetTimer(float time)
    {
        fWaitTime = time;
        fCurrentTime = fWaitTime;
        bActive = true;
        bFinished = false;
        //Debug.Log($"fWaitTime：{fWaitTime}");
    }
    public bool OnTimer()
    {
        if (bFinished == true)
        {
            bFinished = false;
            return true;
        }
        return false;
    }

    public void CloseTimer()
    {
        bActive = false;
        bFinished = false;
        fCurrentTime = fWaitTime;
    }

    public void ResetTimer()
    {
        if (bActive == false)
        {
            Debug.Log($"{this}Reset失败：定时器未激活");
            return;
        }
        fCurrentTime = fWaitTime;
    }
}