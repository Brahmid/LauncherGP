using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApplicationInfoPanel : MonoBehaviour
{
    [SerializeField]
    Button CloseButton;


    // Start is called before the first frame update
    void Awake()
    {
        CloseButton.onClick.AddListener(CloseInfo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Setup(string name)
    {

    }

    void CloseInfo()
    {
        gameObject.SetActive(false);
    }
}
