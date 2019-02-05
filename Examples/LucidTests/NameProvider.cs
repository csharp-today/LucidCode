namespace Examples.LucidTests
{
    class NameProvider : INameProvider
    {
        public string GetUserName(int userId)
        {
            switch (userId)
            {
                case 0: return "Admin";
                case 1: return "Boss";
            }
            return null;
        }
    }
}
