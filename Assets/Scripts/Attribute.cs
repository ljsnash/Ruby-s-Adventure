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
        Debug.Log($"{Name}��ǰ����ֵ:{Health_Current}");
        UIHealthBar.Instance.SetWidth(GetHealthPercent());
    }

    public int GetCurrentHealth()
    {
        Debug.Log($"{Name}��ǰ����ֵ:{Health_Current}");
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
                Debug.Log($"{Name}��ǰ����ֵ�����˱仯���仯��Ϊ{Health_Current}");
                return true;
            }
            else
            {
                Debug.Log($"{Name}��ǰ����ֵû�з����仯����Ϊ{Health_Current}");
                return false;
            }
        }
        Debug.Log($"{Name}��ǰ����ֵ:{Health_Current}");
        Debug.Log($"{Name}��ǰ��������");
        return false;
    }

    public void BeDead()
    {
        bDead = true;
        Debug.Log($"{Name}������");
    }
    public void BeRevived()
    {
        bDead = false;
        Debug.Log($"{Name}����");
    }

    public float GetHealthPercent()
    {
        return Health_Current / (float)Health_Max;
    }
}
