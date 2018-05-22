using UnityEngine;

public class FollowMouse : MonoBehaviour {

    private Vector3 worldMousePosition;
    private SpriteRenderer spriteRender;

    public static float expansionTimer;
    public static float expansionAmount;

    //------------Metodos API------------
    // Al nacer consigue su SpriteRenderer.
    private void Awake()
    {
        spriteRender = this.GetComponent<SpriteRenderer>();       
    }

    //Si no está detenido el tiempo, colocar el crosshair en la posición del mouse.
    void Update()
    {
        if (Time.timeScale > 0)
        {
            worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            worldMousePosition.z = 0;
            this.transform.position = worldMousePosition;
        }

        //Expansion test
        if (expansionTimer >= 0 && Time.timeScale > 0)
        {
            this.transform.localScale += new Vector3(0.3f, 0.3f, 0);
            expansionTimer -= Time.deltaTime;
        }
        else
        {
            if (this.transform.localScale.x != 3)
            {
                this.transform.localScale = new Vector3(1, 1, this.transform.localScale.z);
            }
        }
    }
    //---------Metodos custom------------
    //Activar y desactivar gracias al renderer el crosshair.
    public void EnableInGameMouse()
    {
        spriteRender.enabled = true;
    }

    public void DisableInGameMouse()
    {
        spriteRender.enabled = false;
    }


}
