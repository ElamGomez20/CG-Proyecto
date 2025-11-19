using UnityEngine;

public class FinishGameTrigger : MonoBehaviour
{
    public FinalGameUI finalGameUI;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        if (finalGameUI != null)
        {
            finalGameUI.ShowFinalPanel();
        }
        else
        {
            FinalGameUI ui = FindObjectOfType<FinalGameUI>();
            if (ui != null)
            {
                ui.ShowFinalPanel();
            }
        }
    }
}
