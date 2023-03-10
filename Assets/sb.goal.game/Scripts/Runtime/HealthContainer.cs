using UnityEngine.UI;
using UnityEngine;

public class HealthContainer : MonoBehaviour
{
    private int Count { get; set; }

    [SerializeField] Sprite fill;
    [SerializeField] Sprite empty;

    private void Awake()
    {
        Count = transform.childCount;
        ResetMe();
    }

    public bool TakeDamage()
    {
        Count--;

        if (Count <= 0)
        {
            return true;
        }

        transform.GetChild(Count).GetComponent<Image>().sprite = empty;
        return false;
    }

    private void ResetMe()
    {
        Count = transform.childCount;
        for (int i = transform.childCount - 1; i > 0; i--)
        {
            transform.GetChild(i).GetComponent<Image>().sprite = fill;
        }
    }
}
