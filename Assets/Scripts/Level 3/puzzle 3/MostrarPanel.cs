using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MostrarPanel : MonoBehaviour
{
    public GameObject panel;
    public TMP_InputField inputField;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        panel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GigaPlayer"))
        {
            panel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            inputField.ActivateInputField(); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("GigaPlayer"))
        {
            panel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
