namespace PostGreBE.Constants
{
    public class Authorization
    {
        public enum Roles
        {
            Administrator,
            Moderator,
            User
        }

        public const string default_username = "user";
        public const string default_email = "user@secureapi.com";
        public const string default_password = "P@55w0rD";
        public const Roles default_role = Roles.User;
    }
}
