using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    [SerializeField] GameObject VFX;
    [SerializeField] Text statusText;

    private Button continueBtn;

    private void OnEnable()
    {
        VFX.SetActive(true);
    }

    private void Awake()
    {
        continueBtn = statusText.GetComponent<Button>();
    }

    private IEnumerator Start()
    {
        float et = 0.0f;
        float loadingTime = Random.Range(2.25f, 4.5f);

        int index = 0;
        statusText.text = string.Empty;
        char[] letters = "Loading..".ToCharArray();

        float timeOffset = 0.1f;

        while(et < loadingTime)
        {
            if(index > letters.Length - 1)
            {
                index = 0;
                statusText.text = string.Empty;
            }

            statusText.text += letters[index];
            index++;

            et += timeOffset;
            yield return new WaitForSeconds(timeOffset);
        }

        statusText.text = "PRESS TO CONTINUE";
        continueBtn.onClick.AddListener(() =>
        {
            UIManager.OpenWindow(Window.Menu, gameObject);
        });
    }
}
