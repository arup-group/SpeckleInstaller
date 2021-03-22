using Piwik.Tracker;
using System.Runtime.InteropServices;
using System;
using SpeckleCore;
using System.Globalization;

namespace analytics
{
    class Program
    {
        private static readonly string PiwikBaseUrl = "https://arupdt.matomo.cloud/";
        private static readonly int SiteId = 1;

        static void Main(string[] args)
        {
            var _piwikTracker = new PiwikTracker(SiteId, PiwikBaseUrl);
            var _action = args[0];
            var _version = args[1];
            var _domain = args[2];
            var _machineName = Environment.MachineName.ToLower(new CultureInfo("en-GB", false));
            // Only track users from specific domains (not general public)
            if(_machineName.Contains(_domain)) {
                // Set telemetry to true in the database
                LocalContext.Init();
                LocalContext.SetTelemetrySettings(true);
                // Send this information to Matomo
                _piwikTracker.DoTrackEvent("SpeckleInstaller", _action, _version); 
            }
        }

    }
}
