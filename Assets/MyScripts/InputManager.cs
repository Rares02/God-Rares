using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private PlayerInput input;
    public BuildingViewer bv;
    public LayerMask layerMask;
    public void MouseLeft(InputAction.CallbackContext context) {
        if (context.phase == InputActionPhase.Performed) {
            if(TryRayOnTerrain(4000, layerMask, out RaycastHit hit)) {

                if(hit.transform.TryGetComponent(out ExagoneCell exagoneCell)){
                    exagoneCell.OnClick();
                }
                
            }
            else {
                bv.CloseAllPanels();
            }
        }
        if (context.phase == InputActionPhase.Canceled) {
        }
    }

    public static bool TryRayOnTerrain(float maxDistance, LayerMask layerMask, out RaycastHit hit) {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, maxDistance, layerMask)) { 
            return true;
        }
        return false;
    }
}
