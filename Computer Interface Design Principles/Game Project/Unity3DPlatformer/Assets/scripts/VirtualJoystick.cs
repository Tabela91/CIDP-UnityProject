using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {

    private Image bgImg;
    private Image joystickImg;
    private Vector3 inputVector;

    private void Start()
    {
        bgImg = GetComponent<Image>();
        joystickImg = transform.GetChild(0).GetComponent<Image>();
    }

    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform
                                                                    , ped.position
                                                                    , ped.pressEventCamera
                                                                    , out pos))
        {
            //get coordinates of where you touch/click point
            pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);


            // the following will ensure that the coordinates on the 
            //joystick are -1X to 1X and -1Y to 1Y
            inputVector = new Vector3(pos.x*2 + 1  , 0, pos.y*2 -1);
            inputVector = (inputVector.magnitude > 1.0f) ?inputVector.normalized : inputVector;

            //Move Joystick IMG
                                                                                            //these modifiers determine how far
                                                                                            //from the centre the joystick knob will 
            joystickImg.rectTransform.anchoredPosition = new Vector3(inputVector.x * (bgImg.rectTransform.sizeDelta.x / 4)
                                                                    , inputVector.z * (bgImg.rectTransform.sizeDelta.y / 4));

            Debug.Log(inputVector);
        }
    }
    //When left mouse button is held down, run OnDrag Method
    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }
    //Resets joystick position after pointer is let go
    public virtual void OnPointerUp(PointerEventData ped)
    {
        inputVector = Vector3.zero;
        joystickImg.rectTransform.anchoredPosition = Vector3.zero;
    }
    //assign forward movement value
    public float Vertical()
    {
        if (inputVector.z != 0)
            return inputVector.z;
        else
            return Input.GetAxis("MoveZ");
    }
    //assign left/right movement value
    public float Horizontal()
    {
        if (inputVector.x != 0)
            return inputVector.x;
        else
            return Input.GetAxis("Horizontal");
    }

   
   
}
