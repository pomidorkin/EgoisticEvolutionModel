using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacialExpressionHandler : MonoBehaviour
{
    // Similar to RhubarbSprite.cs

    [SerializeField] Material face;
    [SerializeField] private FacialAnimationsSet facialAnimsSet;

    public FacialAnimationsSet FacialAnimationsSet
    {
        get { return facialAnimsSet; }
        set { facialAnimsSet = value; }
    }

    /*private void Awake()
    {
        mat = GetComponent<Material>();
    }*/

    public FacialExpression FacialExpression
    {
        set
        {
            /*if (PauseMenu.gameIsPaused == false && Application.isPlaying)
            {
                if (eyebrows == null)
                {
                    eyebrows = transform.gameObject;
                }
                Debug.Log("FacialExpression called");
                iTween.MoveTo(eyebrows, iTween.Hash("position", facialAnimsSet.GetEyeBrowPosition(value), "easeType", "easeOutCirc", "islocal", true, "time", .5f));
            }*/
            face.mainTexture = (facialAnimsSet.GetFace(value));
        }
    }
}
