using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    public static UIHealthBar Instance { get; private set;}
    public Image mask;
    private float originzeSize;

    private void Awake()
    {
        Instance = this;//���þ�̬ʵ��Ϊ��ǰ�����
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log($"mask.name = {mask.name}");
        originzeSize = mask.rectTransform.rect.width;
       
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log($"width = {mask.rectTransform.rect.width}");
    }

    public void SetWidth(float percent)
    {
        Debug.Log($"percent = {percent}");
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originzeSize * percent);
    }

    public float GetOriginzeWidth()
    {
        return originzeSize;
    }


}
