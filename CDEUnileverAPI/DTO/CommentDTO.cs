namespace CDEUnileverAPI.DTO
{
    public class CommentDTO
    {
        //public int UserId { get; set; }
        public string Content { get; set; }
        public float Rating { get; set; } = 0;
    }
    public class ShowCommentListDTO
    {
        public string UserFullName { get; set; }
        public string Content { get; set; }
    }
}
