using UnityEngine.UI;
using UnityEngine;

public class Shirts : MonoBehaviour
{
    public static string ShirtKey { get => "shirt"; }

    [SerializeField] Button backBtn;

    [Space(10)]
    [SerializeField] Transform shirts;
    [SerializeField] Transform hover;

    private void Start()
    {
        backBtn.onClick.AddListener(() =>
        {
            Destroy(gameObject);
        });

        hover.transform.position = shirts.GetChild(PlayerPrefs.GetInt(ShirtKey)).position;

        foreach (Transform shirt in shirts)
        {
            shirt.GetComponent<Button>().onClick.AddListener(() =>
            {
                hover.position = shirt.position;

                PlayerPrefs.SetInt(ShirtKey, shirt.GetSiblingIndex());
                PlayerPrefs.Save();
            });
        }
    }
}
