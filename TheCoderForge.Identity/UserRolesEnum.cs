namespace TheCoderForge.Identity
{
    /// <summary>The default set of  UserRoles used by an application</summary>
    public enum UserRolesEnum
    {

        /// <summary>The owner of the application</summary>
        Owner = 0,
        /// <summary>The user designated as Administrator by the owner</summary>
        Administrator,
        /// <summary>A user who is the Manager of a tenants users</summary>
        Manager,
        /// <summary>Ordinary user</summary>
        User
    }
}
