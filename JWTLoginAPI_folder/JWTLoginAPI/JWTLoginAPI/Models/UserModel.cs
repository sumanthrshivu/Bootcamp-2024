namespace JWTLoginAPI.Models
{
    public class UserModel
    {
        public int Id { get; set; } = 0;

        public int pageSize { get; set; } = 5;

        public int pageNumber { get; set; } = 1;

        public string? searchstring { get; set; }

    }
    public class UserListResult
    {
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
        public List<Register>? Users { get; set; }
        public int TotalUsers { get; set; }
    }

}
