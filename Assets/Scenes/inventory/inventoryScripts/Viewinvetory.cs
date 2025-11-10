using UnityEngine;

public class ToggleCanvasWithG : MonoBehaviour
{
    [SerializeField] private Canvas canvas; 

    private void Start()
    {
        if (canvas != null)
            canvas.enabled = false; 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (canvas != null)
                canvas.enabled = !canvas.enabled;
        }
    }
}
