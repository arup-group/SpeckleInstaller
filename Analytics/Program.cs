using Piwik.Tracker;
using System;
using SpeckleCore;
using System.Globalization;
using System.IO;

namespace analytics
{
    class Program
    {
        private static readonly string PiwikBaseUrl = "https://arupdt.matomo.cloud/";
        private static readonly int SiteId = 1;
        private static readonly string CacheLocation = "\\SpeckleSettings\\SpeckleCache.db";

        static void Main(string[] args)
        {
            PiwikTracker _piwikTracker = new PiwikTracker(SiteId, PiwikBaseUrl);
            string _version = args[0];
            string _allowedDomain = args[1];
            string _machineName = Environment.MachineName.ToLower(new CultureInfo("en-GB", false));            
            string _appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            // Check to see if this is an update or it's a new user.
            string _installType = File.Exists(_appDataFolder + CacheLocation) ? "update" : "new";
            
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
