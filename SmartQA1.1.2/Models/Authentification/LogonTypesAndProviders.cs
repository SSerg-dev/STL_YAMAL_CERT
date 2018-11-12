namespace SmartQA1._1._2.Models.Login
{
    //this are the constants for the function LogonUser of 
    //Win32 API
    //see https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-logonusera 
    public enum LogonTypes
    {
        LOGON32_LOGON_BATCH = 4,
        LOGON32_LOGON_INTERACTIVE = 2,
        LOGON32_LOGON_NETWORK = 3,
        LOGON32_LOGON_NETWORK_CLEARTEXT = 8,
        LOGON32_LOGON_NEW_CREDENTIALS = 9,
        LOGON32_LOGON_SERVICE = 5,
        LOGON32_LOGON_UNLOCK = 7
    }
    public enum LogonProviders
    {
        LOGON32_PROVIDER_DEFAULT = 0,
        LOGON32_PROVIDER_WINNT50 = 3,
        LOGON32_PROVIDER_WINNT40 = 2
    }
}