using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private PlayerInput input;
    private static Vector2 mousePosition;
    [SerializeField]private CellManager cellManager;



    private void Update() {
        mousePosition = input.actions["MousePosition"].ReadValue<Vector2>();
    }
    public void MouseLeft(InputAction.CallbackContext context) {
        if (context.phase == InputActionPhase.Performed) {
            cellManager.OnClick();
        }
        if (context.phase == InputActionPhase.Canceled) {
        }
    }



    public static bool TryRaycast(float maxDistance, out RaycastHit hit) {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(mousePosition.x, mousePosition.y, 0));
        if (Physics.Raycast(ray, out hit, maxDistance) && !EventSystem.current.IsPointerOverGameObject()) { 
            return true;
        }
        return false;
    }
}
