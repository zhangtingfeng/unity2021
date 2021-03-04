using UnityEngine;
using System;

/// Time iteration class.
///
/// Component of the sky dome parent game object.

public class TOD_Time : MonoBehaviour
{
    /// Day length inspector variable.
    /// Length of one day in minutes.
    public float DayLengthInMinutes = 30;

    /// Time progression inspector variable.
    /// Automatically updates Cycle.Hour if enabled.
    public bool ProgressTime = true;

    /// Date progression inspector variable.
    /// Automatically updates Cycle.Day if enabled.
    public bool ProgressDate = true;

    /// Moon phase progression inspector variable.
    /// Automatically updates Moon.Phase if enabled.
    public bool ProgressMoonPhase = true;

    private TOD_Sky sky;

    private float hourIter;
    private float moonIter;

    protected void Start()
    {
        sky = GetComponent<TOD_Sky>();
    }

    protected void Update()
    {
        const float hourUpdate = 1f / 3600f;
        const float moonUpdate = 1f / 10000f;

        float oneDay  = DayLengthInMinutes * 60;
        float oneHour = oneDay / 24;

        if (ProgressTime)
        {
            hourIter += Time.deltaTime / oneHour;

            if (hourIter > hourUpdate)
            {
                if (ProgressDate)
                {
                    sky.Cycle.DateTime = sky.Cycle.DateTime.Add(TimeSpan.FromHours(hourIter));
                }
                else
                {
                    sky.Cycle.Hour += hourIter;
                    sky.Cycle.CheckRange();
                }

                hourIter = 0;
            }
        }

        if (ProgressMoonPhase)
        {
            moonIter += Time.deltaTime / (30*oneDay) * 2;

            if (moonIter > moonUpdate)
            {
                sky.Cycle.MoonPhase += moonIter;
                if (sky.Cycle.MoonPhase < -1) sky.Cycle.MoonPhase += 2;
                else if (sky.Cycle.MoonPhase > 1) sky.Cycle.MoonPhase -= 2;
            }

            moonIter = 0;
        }
    }
}
