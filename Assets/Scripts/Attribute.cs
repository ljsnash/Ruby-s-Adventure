using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attribute : MonoBehaviour
{
    public string Name;
    public int Health_Min = 0;
    public int Health_Max = 100;
    private int Health_Current;
    private bool bDead;
    public int Level;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
    }
    public void SetCurrentHealth(int Health)
    {
        Health_Current = Health;
        Debug.Log($"{Name}当前生命值:{Health_Current}");
        UIHealthBar.Instance.SetWidth(GetHealthPercent());
    }

    public int GetCurrentHealth()
    {
        Debug.Log($"{Name}当前生命值:{Health_Current}");
        return Health_Current;
    }

    public bool ChangeHealth(int Health_Change)
    {
        if (bDead == false)
        {
            int newHealth = Mathf.Clamp(Health_Current + Health_Change, Health_Min, Health_Max);
            if (Health_Current != newHealth)
            {
                SetCurrentHealth(newHealth);
                if (Health_Current <= Health_Min)
                {
                    BeDead();
                }
                Debug.Log($"{Name}当前生命值发生了变化，变化后为{Health_Current}");
                return true;
            }
            else
            {
                Debug.Log($"{Name}当前生命值没有发生变化，仍为{Health_Current}");
                return false;
            }
        }
        Debug.Log($"{Name}当前生命值:{Health_Current}");
        Debug.Log($"{Name}当前已死亡！");
        return false;
    }

    public void BeDead()
    {
        bDead = true;
        Debug.Log($"{Name}死掉了");
    }
    public void BeRevived()
    {
        bDead = false;
        Debug.Log($"{Name}活了");
    }

    public float GetHealthPercent()
    {
        return Health_Current / (float)Health_Max;
    }
}
