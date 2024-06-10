namespace InsuranceAggregator.Models
{
    public class AccountViweModel
    {
        public string Title;
        public string errorMessage;
        public int ErrorCode;
        
        public AccountViweModel(string title, string error, int errorCode)
        {
            this.Title = title;
            this.errorMessage = error;
            this.ErrorCode = errorCode;
        }
    }
    public class ErrorModel { 
        public string ErrorMessage;
        public string Title;
        public int ErrorCode;
    }
}
