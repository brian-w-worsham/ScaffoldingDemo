using System.ComponentModel.DataAnnotations;

namespace ScaffoldingDemo.Models
{
    public class Friend
    {
        [Key]
        public int FriendID { get; set; }

        public string FriendName { get; set; }

        public string CompanyName { get; set; }

        public string Email { get; set; }
    }
}
