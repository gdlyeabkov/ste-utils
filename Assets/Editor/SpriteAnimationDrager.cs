using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq.Expressions;

[CustomEditor(typeof(Transform))]
public class SpriteAnimationDrager : Editor
{

    public void OnSceneGUI()
    {
        Event currentEvent = Event.current;
        EventType currentEventType = currentEvent.type;
        EventType dragUpdatedEventType = EventType.DragUpdated;
        bool isDragUpdatedEventType = currentEventType == dragUpdatedEventType;
        if (isDragUpdatedEventType)
        {
            EditorApplication.ExecuteMenuItem("Window/Animation/Animation");
        }
    }

}