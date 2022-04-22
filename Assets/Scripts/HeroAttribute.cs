using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttribute : Attribute
{
    private bool IsTalk = false;
    // Start is called before the first frame update
    void Start()
    {
        SetCurrentHealth(Health_Max - 200);
        GetCurrentHealth();
    }

    // Update is called once per frame
    void Update()
    {
        //ChangeHealth(-50);
    }

    public void SetTalkState(bool isTalk)
    {
        IsTalk = isTalk;
    }

    public bool GetTalkState()
    {
        return IsTalk;
    }
}
