using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour {
    private Vector3 ultimaPosizioneMouse;
    private bool staTrascinando = false;

    [SerializeField] private PlayerInput inputManager;
    private InputActionMap mouseActionsMap;
    private InputAction mouseRightClick;
    private InputAction mouseScrollWheel;

    private float scrollWheelValue;
    [SerializeField] private float zoomVelocity = 1;
    [SerializeField] private float zoomInLimit = 5;
    [SerializeField] private float zoomOutLimit = 90;

    private float dragVelocity;
    [SerializeField] private float dragMinVelocity = 0.5f;
    [SerializeField] private float dragMaxVelocity = 3.5f;
    
    // Limiti modificabili da Inspector
    public float limiteXMinimo = -25;
    public float limiteXMassimo = 25;
    public float limiteZMinimo = -25;
    public float limiteZMassimo = 25;

    public Vector2 cameraOffset = new Vector2(0.0f, 5.0f);

    private void Start() {
        mouseActionsMap = inputManager.actions.FindActionMap("PlayerController");
        mouseRightClick = mouseActionsMap.actions[1];
        mouseScrollWheel = mouseActionsMap.actions[3];

        mouseRightClick.performed += MouseRightClick_performed;
        mouseRightClick.canceled += MouseRightClick_canceled;
    }

    private void MouseRightClick_performed(InputAction.CallbackContext obj) {
        Debug.Log(Input.mousePosition.x);
        Debug.Log(Input.mousePosition.y);
        Debug.Log("Sto tenendo premuto il tasto sinistro del mouse");
        staTrascinando = true;
        ultimaPosizioneMouse = Input.mousePosition;
    }

    private void MouseRightClick_canceled(InputAction.CallbackContext obj) {
        Debug.Log("Ho rilasciato il tasto del mouse");
        staTrascinando = false;
    }


    void Update() {
        scrollWheelValue = mouseScrollWheel.ReadValue<float>();
        //dragVelocity = 2.5f * Mathf.Pow(transform.position.y, 1.1f) / zoomOutLimit;
        dragVelocity = dragMinVelocity + Math.Abs((transform.position.y - zoomInLimit)) * Math.Abs((dragMaxVelocity - dragMinVelocity)) / Math.Abs((zoomOutLimit - zoomInLimit)); 


        if (scrollWheelValue > 0) {
            if (Camera.main.transform.position.y > zoomInLimit) {
                Vector3 position = Camera.main.transform.position + Camera.main.transform.forward * zoomVelocity;
                position.y = Mathf.Clamp(position.y, zoomInLimit, zoomOutLimit);
                Camera.main.transform.position = position;
            }
        }
        else if (scrollWheelValue < 0) {
            if (transform.position.y < zoomOutLimit) {
                Vector3 position = Camera.main.transform.position - Camera.main.transform.forward * zoomVelocity;
                position.y = Mathf.Clamp(position.y, zoomInLimit, zoomOutLimit);
                Camera.main.transform.position = position;
            }
        }

        // Se l'utente sta trascinando il mouse
        if (staTrascinando) {
            // Calcola il movimento del mouse
            Vector3 delta = Input.mousePosition - ultimaPosizioneMouse;
            delta = new Vector3(delta.x, 0, delta.y); // Muove solo sugli assi X e Z
            delta *= dragVelocity * Time.deltaTime;

            // Applica il movimento alla posizione della telecamera
            Vector3 nuovaPosizione = transform.position - delta;

            // Limita la posizione della telecamera all'interno dei confini specificati
            nuovaPosizione.x = Mathf.Clamp(nuovaPosizione.x, limiteXMinimo, limiteXMassimo);
            nuovaPosizione.z = Mathf.Clamp(nuovaPosizione.z, limiteZMinimo, limiteZMassimo);

            // Imposta la nuova posizione della telecamera
            transform.position = nuovaPosizione;

            // Aggiorna l'ultima posizione del mouse
            ultimaPosizioneMouse = Input.mousePosition;
        }
    }
}