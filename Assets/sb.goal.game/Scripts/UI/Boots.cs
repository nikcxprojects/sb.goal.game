using UnityEngine.UI;
using UnityEngine;
using System.Linq;

public class Boots : MonoBehaviour
{
    public static string BootsKey { get => "boot"; }

    [SerializeField] Button backBtn;

    [Space(10)]
    [SerializeField] Transform boots;
    [SerializeField] Transform hover;

    private void Start()
    {
        backBtn.onClick.AddListener(() =>
        {
            Destroy(gameObject);
        });

        hover.transform.position = boots.GetChild(PlayerPrefs.GetInt(BootsKey)).position;

        foreach (Transform boot in boots)
        {
            boot.GetComponent<Button>().onClick.AddListener(() =>
            {
                hover.position = boot.position;

                PlayerPrefs.SetInt(BootsKey, boot.GetSiblingIndex());
                PlayerPrefs.Save();

                FindObjectsOfType<MonoBehaviour>().OfType<IMenu>().FirstOrDefault()?.UpdateMenuIcons();
            });
        }
    }
}
