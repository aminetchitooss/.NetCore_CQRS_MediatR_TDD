using System;
namespace TDD_Sample_dotNet.Models
{
    public class User
    {
        public User()
        {

        }
        public User(string userName, int age)
        {
            UserName = userName;
            Age = age;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }

    }
}
