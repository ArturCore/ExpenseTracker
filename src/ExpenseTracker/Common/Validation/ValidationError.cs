namespace ExpenseTracker.Api.Common.Validation
{
    public class ValidationError
    {
        public string Field {  get; set; }
        public string Message { get; set; }
        public string Code { get; set; }
    }
}
