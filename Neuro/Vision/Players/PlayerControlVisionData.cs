﻿using Neuro.Utilities;
using UnityEngine;

namespace Neuro.Vision.Players;

// TODO: ReportFindings was removed
public sealed class PlayerControlVisionData
{
    public Vector2 LastSeenPosition { get; private set; }
    public float LastSeenTime { get; private set; }
    public bool SawVent { get; private set; }
    public float RoundTimeVisible { get; private set; }
    public float GameTimeVisible { get; private set; }

    private PlayerControlVisionData()
    {
    }

    public static PlayerControlVisionData Create()
    {
        return new PlayerControlVisionData();
    }

    public void UpdateVisible(PlayerControl owner)
    {
        if (owner.MyPhysics.Animations.IsPlayingEnterVentAnimation() || owner.MyPhysics.Animations.IsPlayingExitVentAnimation())
        {
            SawVent = true;
        }

        if (owner.inVent) return;

        LastSeenPosition = owner.GetTruePosition();
        LastSeenTime = Time.fixedTime;
        RoundTimeVisible += Time.fixedDeltaTime;
        GameTimeVisible += Time.fixedDeltaTime;
    }

    public void ResetAfterMeeting()
    {
        SawVent = false;
        RoundTimeVisible = 0;
    }
}
