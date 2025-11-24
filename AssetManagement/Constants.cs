namespace AssetManagement
{
    public class Constants
    {
        public const string BaseVersion = "1.0.0";
        public const string BaseTitle = "FST Digital System";
        public const string UserDefaultPassword = "1q2w3e4r!@";

        public class Common
        {
            public const int MinNameLength = 2;
            public const int MaxNameLength = 20;
        }

        public class Identity
        {
            public const int MinUserNameLength = 3;
            public const int MaxUserNameLength = 20;
            public const int MinEmailLength = 3;
            public const int MaxEmailLength = 50;
            public const int MinPasswordLength = 6;
            public const int MinRoleNameLength = 3;
            public const int MaxRoleNameLength = 20;
        }
    }
}
