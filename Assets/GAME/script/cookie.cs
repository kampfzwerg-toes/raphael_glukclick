using UnityEngine;
using UnityEngine.InputSystem;

public class cookie : MonoBehaviour
{
    public float clickScale = 0.9f;
    public float returnSpeed = 10f;

    Collider2D cookieCollider;
    Vector3 normalScale;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cookieCollider = GetComponent<Collider2D>();
            normalScale = transform.localScale; 
    }

    // Update is called once per frame
    void Update()
    {
        // le cookie reprend doucement sa taille normal 
        transform.localScale = Vector3.Lerp(transform.localScale, normalScale, returnSpeed *  Time.deltaTime);

        // Pointer = souris OU doigt sur un écran tactile (New Input System)
        if (Pointer.current == null) return; 

        if (Pointer.current.press.wasPressedThisFrame)
        {
            // 1. Où est la souris à l'écran (en pixels) ? 
            Vector2 screenPosition = Pointer.current.position.ReadValue();

            // 2. On convertit en position dans le monde du jeu 
            Vector2 worldposition = Camera.main.ScreenToWorldPoint(screenPosition);

            // 3. Est-ce que ce point est dans le collider du cookie ? 
            if (cookieCollider.OverlapPoint(worldposition))
            {
                OnCookieClicked(); 
            }
        }    
    }

    void OnCookieClicked()
    {
        Gamemanager.Instance.AddCookies();

        // Petit effet visuel : le cookie s'écrase 
        transform.localScale = normalScale * clickScale; 
    }

}


