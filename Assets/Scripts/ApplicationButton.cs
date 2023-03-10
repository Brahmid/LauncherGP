using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

enum ApplicationType
{
    Exe,
    Web,
    Info
}
public class ApplicationButton : MonoBehaviour
{


    [Header("References")]
    [SerializeField]
    private Button Button;

    [SerializeField]
    private Image Image;

    [SerializeField]
    private RectTransform DescPanel;

    [SerializeField]
    private TMP_Text Label;

    [SerializeField]
    private TMP_Text DescText;

    [Header("Definition")]
    [SerializeField]
    private ApplicationType Type;

    [SerializeField]
    private string Name;

    [SerializeField]
    private string Description;

    [SerializeField]
    private string Path;

    [SerializeField]
    private Sprite Thumbnail;

    
    private void Awake()
    {
  
        Button.onClick.AddListener(ButtonPresed);
        DescPanel.gameObject.SetActive(false);
        SetupDefinition();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    void ButtonPresed()
    {
        switch (Type)
        {
            case ApplicationType.Exe:
                RunApplication.Instance.LaunchApp(Path, name);
                break;
            case ApplicationType.Web:
                RunApplication.Instance.LaunchWeb(Path, name);
                break;
            case ApplicationType.Info:
                RunApplication.Instance.LaunchInfo(Path, name);
                break;
            default:
                break;
        }
    }

    public void OnMouseEnter()
    {
        DescPanel.gameObject.SetActive(true);
    }

    public void OnMouseExit()
    {
        DescPanel.gameObject.SetActive(false);
    }

    [ContextMenu("Setup")]
    public void SetupDefinition()
    {
        Label.text = Name;
        DescText.text = Description;
        Image.sprite = Thumbnail;
    }
}
