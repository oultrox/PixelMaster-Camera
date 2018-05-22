using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class PixelResolution : MonoBehaviour
{
    [SerializeField] private int referenceWidth = 320;
    [SerializeField] private int referenceHeight = 180;
    [SerializeField] private int pixelsPerUnit = 32;
    [SerializeField] private bool runEveryTick = true;
    private Camera cam;

    void Awake()
    {
        cam = GetComponent<Camera>();
        SetPixelResolution();
        SetRatio();
    }

    // Executes this everytime if you want resizing viewport in-game easily.
    void Update()
    {
        if (runEveryTick)
        {
            SetPixelResolution();
            SetRatio();
        }
    }

    private void SetPixelResolution()
    {
        /*
			Orthographic size is half of reference resolution since it is measured
			from center to the top of the screen.
		*/
        cam.orthographicSize = (referenceHeight / 2) / (float)pixelsPerUnit;
    }

    private void SetRatio()
    {
        // set the desired aspect ratio
        float targetaspect = (float)referenceWidth / (float)referenceHeight;

        // determine the game window's current aspect ratio
        float windowaspect = (float)Screen.width / (float)Screen.height;

        // current viewport height should be scaled by this amount
        float scaleheight = windowaspect / targetaspect;

        // if scaled height is less than current height, add letterbox
        if (scaleheight < 1.0f)
        {
            Rect rect = cam.rect;

            rect.width = 1.0f;

            rect.height = scaleheight;
            rect.x = 0;
            rect.y = (1.0f - scaleheight) / 2.0f;

            cam.rect = rect;
        }
        else
        {
            // add pillarbox
            float scalewidth = 1.0f / scaleheight;

            Rect rect = cam.rect;

            rect.width = scalewidth;

            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;

            cam.rect = rect;

        }
    }

    // Creates the RenderTexture buffer
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        RenderTexture buffer = RenderTexture.GetTemporary(referenceWidth, referenceHeight, -1);

        buffer.filterMode = FilterMode.Point;
        source.filterMode = FilterMode.Point;

        Graphics.Blit(source, buffer);
        Graphics.Blit(buffer, destination);

        RenderTexture.ReleaseTemporary(buffer);
    }

    #region Properties
    public int ReferenceWidth
    {
        get
        {
            return referenceWidth;
        }

        set
        {
            referenceWidth = value;
        }
    }

    public int ReferenceHeight
    {
        get
        {
            return referenceHeight;
        }

        set
        {
            referenceHeight = value;
        }
    }

    public int PixelsPerUnit
    {
        get
        {
            return pixelsPerUnit;
        }

        set
        {
            pixelsPerUnit = value;
        }
    }
    #endregion
}