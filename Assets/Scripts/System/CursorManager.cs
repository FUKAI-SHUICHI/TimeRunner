using UnityEngine;

public class CursorManager : MonoBehaviour
{

    public bool isCursor = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (isCursor)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;//マウスカーソルの制限なし
        }

        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;//マウスカーソルを中央に固定
        }
    }

    
}
