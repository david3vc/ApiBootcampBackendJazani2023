namespace Jazani.Api.Exceptions
{
    public class ErrorValidationModel : ErrorModel
    {
        public string FieldName { get; set; }
        public string Message { get; set; }
    }
}
