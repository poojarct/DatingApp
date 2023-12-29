namespace API.Entities
{
    public class UserLike
    {
        public APPUser SourceUser { get; set; }

        public int SourceUserId { get; set; }

        public APPUser TargetUser { get; set; }
        
        public int TargetUserId { get; set; }
    }
}