using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR;
using Valve.VR.Extras;

[RequireComponent(typeof(SteamVR_LaserPointer))]
public class VRRaycastInput : MonoBehaviour
{
    private SteamVR_LaserPointer laserPointer;
    public SteamVR_Action_Boolean UIonOff;
    public SteamVR_Input_Sources handType;
    private Transform LaserTarget;

    void Start()
    {
        UIonOff.AddOnStateDownListener(TriggerDown, handType);
        UIonOff.AddOnStateUpListener(TriggerUp, handType);
    }

    private void OnEnable()
    {
        laserPointer = GetComponent<SteamVR_LaserPointer>();
        laserPointer.PointerIn -= HandlePointerIn;
        laserPointer.PointerIn += HandlePointerIn;
        laserPointer.PointerOut -= HandlePointerOut;
        laserPointer.PointerOut += HandlePointerOut;
    }

    public void TriggerUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("Trigger is up");
        if (LaserTarget != null)
        {
            Button button = LaserTarget.GetComponent<Button>();
            VRAction vrAction = LaserTarget.GetComponent<VRAction>();
            if (button != null)
            {
                button.onClick.Invoke();
            }
            if (vrAction != null)
            {
                vrAction.click();
            }
        }
    }
    public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Debug.Log("Trigger is down");

    }

    private void HandlePointerIn(object sender, PointerEventArgs e)
    {
        Button button = e.target.GetComponent<Button>();
        VRAction vrAction = e.target.GetComponent<VRAction>();
        LaserTarget = e.target;
        if (button != null)
        {
            button.Select();
        }
        if (vrAction != null)
        {
            vrAction.enterHover();
        }
    }

    private void HandlePointerOut(object sender, PointerEventArgs e)
    {

        Button button = e.target.GetComponent<Button>();
        VRAction vrAction = e.target.GetComponent<VRAction>();
        if (button != null)
        {
            EventSystem.current.SetSelectedGameObject(null);
        }
        if (vrAction != null)
        {
            vrAction.exitHover();
        }
    }
}
