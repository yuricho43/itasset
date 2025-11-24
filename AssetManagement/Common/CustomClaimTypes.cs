namespace AssetManagement.Common
{
    //JBH: https://www.jerriepelser.com/blog/useful-claimsprincipal-extension-methods/
    public static class CustomClaimTypes
    {
        public const string UserName    = "urn:yscho:username"; //login name
        public const string HangulName  = "urn:yscho:hangulname";
        public const string Department  = "urn:yscho:department";
        public const string CompanyName = "urn:yscho:companyname";
    }
}
