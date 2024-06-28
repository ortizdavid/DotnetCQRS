namespace AspNetCoreRestApi.Helpers
{
    public class PasswordHelper 
    {
        public static string Hash(string? password)
        {
            if(string.IsNullOrEmpty(password)) {
                throw new ArgumentNullException("Password must have a value");
            }
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool Verify(string? password, string? hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }   

    }
}
