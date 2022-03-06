using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    //Ref Data
    private string refId;
    private string name;
    private Color colour;

    //Dyn Data
    private PartShape charaShape;
    private PartEyes charaEyes;
    private PartNose charaNose;
    private PartMouth charaMouth;

    public Character (string refId, string name, Color colour)
    {
        this.refId = refId;
        this.name = name;
        this.colour = colour;

        charaShape = null;
        charaEyes = null;
        charaNose = null;
        charaMouth = null;
    }

    public string GetRefId()
    {
        return refId;
    }

    public string GetName()
    {
        return name;
    }

    public Color GetColour()
    {
        return colour;
    }

    public FacePart GetFacePartByType(PartType aType)
    {
        switch (aType)
        {
            case PartType.SHAPE:
                return charaShape;
            case PartType.EYES:
                return charaEyes;
            case PartType.NOSE:
                return charaNose;
            case PartType.MOUTH:
                return charaMouth;
        }

        return null;
    }

    public PartShape GetShape()
    {
        return charaShape;
    }

    public void SetShape(PartShape aShape)
    {
        charaShape = aShape;
    }

    public PartEyes GetEyes()
    {
        return charaEyes;
    }

    public void SetEyes(PartEyes aEyes)
    {
        charaEyes = aEyes;
    }

    public PartNose GetNose()
    {
        return charaNose;
    }

    public void SetNose(PartNose aNose)
    {
        charaNose = aNose;
    }

    public PartMouth GetMouth()
    {
        return charaMouth;
    }

    public void SetMouth(PartMouth aMouth)
    {
        charaMouth = aMouth;
    }

    public bool CheckHasPart(string aRefId)
    {
        return charaShape.GetRefId() == aRefId || charaEyes.GetRefId() == aRefId || charaNose.GetRefId() == aRefId || charaMouth.GetRefId() == aRefId;
    }
}
