using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRM;

public class FaceExpressionsControllerVRM : MonoBehaviour
{
    private OVRFaceExpressions ovrExpressions;
    private VRMBlendShapeProxy proxy;

    Dictionary<BlendShapeKey, float> clipValueDatas;

    void Start()
    {
        ovrExpressions = GetComponent<OVRFaceExpressions>();
        proxy = this.GetComponentInParent<VRMBlendShapeProxy>();
        SetClipValueDataInfo();
    }

    void Update()
    {
        if (ovrExpressions == null ||
            proxy == null ||
            clipValueDatas == null)
        {
            return;
        }

        if (ovrExpressions.enabled &&
            ovrExpressions.FaceTrackingEnabled &&
            ovrExpressions.ValidExpressions)
        {
            if (clipValueDatas.Count == (int)OVRPlugin.FaceExpression.Max)
            {
                for (int expressionCnt = 0; expressionCnt < clipValueDatas.Count; expressionCnt++)
                {
                    clipValueDatas[keys[expressionCnt]] = ovrExpressions[(OVRFaceExpressions.FaceExpression)expressionCnt];
                }

                proxy.SetValues(clipValueDatas);
            }
        }
    }

    void SetClipValueDataInfo()
    {
        clipValueDatas = new Dictionary<BlendShapeKey, float>()
        {
            {BlendShapeKey.CreateUnknown("BrowLowererL"),           0.0f },
            {BlendShapeKey.CreateUnknown("BrowLowererR"),           0.0f },
            {BlendShapeKey.CreateUnknown("CheekPuffL"),             0.0f },
            {BlendShapeKey.CreateUnknown("CheekPuffR"),             0.0f },
            {BlendShapeKey.CreateUnknown("CheekRaiserL"),           0.0f },
            {BlendShapeKey.CreateUnknown("CheekRaiserR"),           0.0f },
            {BlendShapeKey.CreateUnknown("CheekSuckL"),             0.0f },
            {BlendShapeKey.CreateUnknown("CheekSuckR"),             0.0f },
            {BlendShapeKey.CreateUnknown("ChinRaiserB"),            0.0f },
            {BlendShapeKey.CreateUnknown("ChinRaiserT"),            0.0f },
            {BlendShapeKey.CreateUnknown("DimplerL"),               0.0f },
            {BlendShapeKey.CreateUnknown("DimplerR"),               0.0f },
            {BlendShapeKey.CreateUnknown("EyesClosedL"),            0.0f },
            {BlendShapeKey.CreateUnknown("EyesClosedR"),            0.0f },
            {BlendShapeKey.CreateUnknown("EyesLookDownL"),          0.0f },
            {BlendShapeKey.CreateUnknown("EyesLookDownR"),          0.0f },
            {BlendShapeKey.CreateUnknown("EyesLookLeftL"),          0.0f },
            {BlendShapeKey.CreateUnknown("EyesLookLeftR"),          0.0f },
            {BlendShapeKey.CreateUnknown("EyesLookRightL"),         0.0f },
            {BlendShapeKey.CreateUnknown("EyesLookRightR"),         0.0f },
            {BlendShapeKey.CreateUnknown("EyesLookUpL"),            0.0f },
            {BlendShapeKey.CreateUnknown("EyesLookUpR"),            0.0f },
            {BlendShapeKey.CreateUnknown("InnerBrowRaiserL"),       0.0f },
            {BlendShapeKey.CreateUnknown("InnerBrowRaiserR"),       0.0f },
            {BlendShapeKey.CreateUnknown("JawDrop"),                0.0f },
            {BlendShapeKey.CreateUnknown("JawSidewaysLeft"),        0.0f },
            {BlendShapeKey.CreateUnknown("JawSidewaysRight"),       0.0f },
            {BlendShapeKey.CreateUnknown("JawThrust"),              0.0f },
            {BlendShapeKey.CreateUnknown("LidTightenerL"),          0.0f },
            {BlendShapeKey.CreateUnknown("LidTightenerR"),          0.0f },
            {BlendShapeKey.CreateUnknown("LipCornerDepressorL"),    0.0f },
            {BlendShapeKey.CreateUnknown("LipCornerDepressorR"),    0.0f },
            {BlendShapeKey.CreateUnknown("LipCornerPullerL"),       0.0f },
            {BlendShapeKey.CreateUnknown("LipCornerPullerR"),       0.0f },
            {BlendShapeKey.CreateUnknown("LipFunnelerLB"),          0.0f },
            {BlendShapeKey.CreateUnknown("LipFunnelerLT"),          0.0f },
            {BlendShapeKey.CreateUnknown("LipFunnelerRB"),          0.0f },
            {BlendShapeKey.CreateUnknown("LipFunnelerRT"),          0.0f },
            {BlendShapeKey.CreateUnknown("LipPressorL"),            0.0f },
            {BlendShapeKey.CreateUnknown("LipPressorR"),            0.0f },
            {BlendShapeKey.CreateUnknown("LipPuckerL"),             0.0f },
            {BlendShapeKey.CreateUnknown("LipPuckerR"),             0.0f },
            {BlendShapeKey.CreateUnknown("LipStretcherL"),          0.0f },
            {BlendShapeKey.CreateUnknown("LipStretcherR"),          0.0f },
            {BlendShapeKey.CreateUnknown("LipSuckLB"),              0.0f },
            {BlendShapeKey.CreateUnknown("LipSuckLT"),              0.0f },
            {BlendShapeKey.CreateUnknown("LipSuckRB"),              0.0f },
            {BlendShapeKey.CreateUnknown("LipSuckRT"),              0.0f },
            {BlendShapeKey.CreateUnknown("LipTightenerL"),          0.0f },
            {BlendShapeKey.CreateUnknown("LipTightenerR"),          0.0f },
            {BlendShapeKey.CreateUnknown("LipsToward"),             0.0f },
            {BlendShapeKey.CreateUnknown("LowerLipDepressorL"),     0.0f },
            {BlendShapeKey.CreateUnknown("LowerLipDepressorR"),     0.0f },
            {BlendShapeKey.CreateUnknown("MouthLeft"),              0.0f },
            {BlendShapeKey.CreateUnknown("MouthRight"),             0.0f },
            {BlendShapeKey.CreateUnknown("NoseWrinklerL"),          0.0f },
            {BlendShapeKey.CreateUnknown("NoseWrinklerR"),          0.0f },
            {BlendShapeKey.CreateUnknown("OuterBrowRaiserL"),       0.0f },
            {BlendShapeKey.CreateUnknown("OuterBrowRaiserR"),       0.0f },
            {BlendShapeKey.CreateUnknown("UpperLidRaiserL"),        0.0f },
            {BlendShapeKey.CreateUnknown("UpperLidRaiserR"),        0.0f },
            {BlendShapeKey.CreateUnknown("UpperLipRaiserL"),        0.0f },
            {BlendShapeKey.CreateUnknown("UpperLipRaiserR"),        0.0f },
        };
    }

    static readonly BlendShapeKey[] keys =
    {
        BlendShapeKey.CreateUnknown("BrowLowererL"),
        BlendShapeKey.CreateUnknown("BrowLowererR"),
        BlendShapeKey.CreateUnknown("CheekPuffL"),
        BlendShapeKey.CreateUnknown("CheekPuffR"),
        BlendShapeKey.CreateUnknown("CheekRaiserL"),
        BlendShapeKey.CreateUnknown("CheekRaiserR"),
        BlendShapeKey.CreateUnknown("CheekSuckL"),
        BlendShapeKey.CreateUnknown("CheekSuckR"),
        BlendShapeKey.CreateUnknown("ChinRaiserB"),
        BlendShapeKey.CreateUnknown("ChinRaiserT"),
        BlendShapeKey.CreateUnknown("DimplerL"),
        BlendShapeKey.CreateUnknown("DimplerR"),
        BlendShapeKey.CreateUnknown("EyesClosedL"),
        BlendShapeKey.CreateUnknown("EyesClosedR"),
        BlendShapeKey.CreateUnknown("EyesLookDownL"),
        BlendShapeKey.CreateUnknown("EyesLookDownR"),
        BlendShapeKey.CreateUnknown("EyesLookLeftL"),
        BlendShapeKey.CreateUnknown("EyesLookLeftR"),
        BlendShapeKey.CreateUnknown("EyesLookRightL"),
        BlendShapeKey.CreateUnknown("EyesLookRightR"),
        BlendShapeKey.CreateUnknown("EyesLookUpL"),
        BlendShapeKey.CreateUnknown("EyesLookUpR"),
        BlendShapeKey.CreateUnknown("InnerBrowRaiserL"),
        BlendShapeKey.CreateUnknown("InnerBrowRaiserR"),
        BlendShapeKey.CreateUnknown("JawDrop"),
        BlendShapeKey.CreateUnknown("JawSidewaysLeft"),
        BlendShapeKey.CreateUnknown("JawSidewaysRight"),
        BlendShapeKey.CreateUnknown("JawThrust"),
        BlendShapeKey.CreateUnknown("LidTightenerL"),
        BlendShapeKey.CreateUnknown("LidTightenerR"),
        BlendShapeKey.CreateUnknown("LipCornerDepressorL"),
        BlendShapeKey.CreateUnknown("LipCornerDepressorR"),
        BlendShapeKey.CreateUnknown("LipCornerPullerL"),
        BlendShapeKey.CreateUnknown("LipCornerPullerR"),
        BlendShapeKey.CreateUnknown("LipFunnelerLB"),
        BlendShapeKey.CreateUnknown("LipFunnelerLT"),
        BlendShapeKey.CreateUnknown("LipFunnelerRB"),
        BlendShapeKey.CreateUnknown("LipFunnelerRT"),
        BlendShapeKey.CreateUnknown("LipPressorL"),
        BlendShapeKey.CreateUnknown("LipPressorR"),
        BlendShapeKey.CreateUnknown("LipPuckerL"),
        BlendShapeKey.CreateUnknown("LipPuckerR"),
        BlendShapeKey.CreateUnknown("LipStretcherL"),
        BlendShapeKey.CreateUnknown("LipStretcherR"),
        BlendShapeKey.CreateUnknown("LipSuckLB"),
        BlendShapeKey.CreateUnknown("LipSuckLT"),
        BlendShapeKey.CreateUnknown("LipSuckRB"),
        BlendShapeKey.CreateUnknown("LipSuckRT"),
        BlendShapeKey.CreateUnknown("LipTightenerL"),
        BlendShapeKey.CreateUnknown("LipTightenerR"),
        BlendShapeKey.CreateUnknown("LipsToward"),
        BlendShapeKey.CreateUnknown("LowerLipDepressorL"),
        BlendShapeKey.CreateUnknown("LowerLipDepressorR"),
        BlendShapeKey.CreateUnknown("MouthLeft"),
        BlendShapeKey.CreateUnknown("MouthRight"),
        BlendShapeKey.CreateUnknown("NoseWrinklerL"),
        BlendShapeKey.CreateUnknown("NoseWrinklerR"),
        BlendShapeKey.CreateUnknown("OuterBrowRaiserL"),
        BlendShapeKey.CreateUnknown("OuterBrowRaiserR"),
        BlendShapeKey.CreateUnknown("UpperLidRaiserL"),
        BlendShapeKey.CreateUnknown("UpperLidRaiserR"),
        BlendShapeKey.CreateUnknown("UpperLipRaiserL"),
        BlendShapeKey.CreateUnknown("UpperLipRaiserR"),
    };
}
