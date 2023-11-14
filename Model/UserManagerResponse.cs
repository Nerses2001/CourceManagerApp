namespace Model
{
    public class UserManagerResponse
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public IEnumerable<string> Errors { get; set; }

        public UserManagerResponse(string message, bool isSuccess, IEnumerable<string> errors)
        {
            this.Message = message;
            this.IsSuccess = isSuccess;
            this.Errors = errors;
        }
    }
}
