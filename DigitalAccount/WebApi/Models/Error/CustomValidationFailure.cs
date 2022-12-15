namespace WebApi.Models.Error
{
    public class CustomValidationFailure
    {
        public CustomValidationFailure(string propertyName, string erroMessage)
        {
            PropertyName= propertyName;
            ErroMessage= erroMessage;
        }

        public string PropertyName { get; set; }
        public string ErroMessage { get; set; }
    }
}
