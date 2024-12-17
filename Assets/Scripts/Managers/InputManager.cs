using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private PlayerInput input;
    private static Vector2 mousePosition;


    private void Update() {
        mousePosition = input.actions["MousePosition"].ReadValue<Vector2>();
    }
    public void MouseLeft(InputAction.CallbackContext context) {
        if (context.phase == InputActionPhase.Performed) {
            if(TryRaycast(4000, out RaycastHit hit)) {
                //Debug.Log(hit.transform.gameObject.layer);
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Default")) {
                    if (hit.transform.TryGetComponent(out ExagoneCell exagoneCell)) {
                        exagoneCell.OnClick();
                    }
                }
                else if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Water")) {
                    UISystem.Instance.BuildingViewer.CloseAllPanels();
                }
            }

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
