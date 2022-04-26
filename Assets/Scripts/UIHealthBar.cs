using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    public static UIHealthBar Instance { get; private set;}
    public Image mask;
    private float originzeSize;
    public HeroAttribute Hero_boli;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;//设置静态实例为当前类对象
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        originzeSize = mask.rectTransform.rect.width;
        Debug.Log($"originzeSize = {originzeSize}");
        Debug.Log($"mask.name = {mask.name}");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log($"width = {mask.rectTransform.rect.width}");
        float percent = Hero_boli.GetHealthPercent();
        Instance.SetWidth(percent);
    }

    public void SetWidth(float percent)
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originzeSize * percent);
    }

    public float GetOriginzeWidth()
    {
        return originzeSize;
    }


}
