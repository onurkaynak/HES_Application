namespace CovidApp
{
    public class BaseResponse<T>
    {
        private ResponseStatusCodes _code;
        public ResponseStatusCodes ResponseStatusCodes
        {
            get
            {
                return _code;
            }
            
            set
            {
                _code = value;
                this.Message = ResponseMessageGenerator.MessageGenerator(value);
            }
        }
        public string Message { get; set; }
        public T? Data { get; set; }
    }
}