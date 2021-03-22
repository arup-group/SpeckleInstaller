using Piwik.Tracker;
using System.Runtime.InteropServices;
using System;
using SpeckleCore;
using System.Globalization;
using System.Diagnostics;
using System.IO;

namespace analytics
{
    class Program
    {
        private static readonly string PiwikBaseUrl = "https://arupdt.matomo.cloud/";
        private static readonly int SiteId = 1;

        static void Main(string[] args)
        {
            PiwikTracker _piwikTracker = new PiwikTracker(SiteId, PiwikBaseUrl);
            String _version = args[0];
            String _allowedDomain = args[1];
            String _machineName = Environment.MachineName.ToLower(new CultureInfo("en-GB", false));            
            String _appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            String _speckleUpdaterExe = _appDataFolder + "\\Speckle\\SpeckleUpdater.exe";

            // Check to see if this is an update or it's a new user.
            String _installType = File.Exists(_speckleUpdaterExe) ? "update" : "new";
            
            // Only track users from specific domains (not general public)
            if(_machineName.Contains(_allowedDomain)) {
                // Sets a flag in the cache database. Used by clients.
                LocalContext.SetTelemetrySettings(true);
                // Send this information to Matomo
                _piwikTracker.DoTrackEvent("SpeckleInstaller", _installType, _version); 
            }
        }

    }
}
