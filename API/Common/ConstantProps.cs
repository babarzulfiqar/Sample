
namespace API.Common
{
    public static class ConstantProps
    {
        public const int maxPageSize = 50;

        //Messages
        public const string dataNotFoundText = "Data not found";
        public const string dataListText = "Data List!";
        public const string InvalidDataModelText = "Invalid Data/Model! Bad Request";
        public const string SubmittedSuccessfullyText = "Submitted Successfully";
        public const string SavedSuccessfullyText = "Saved Successfully";
        public const string DeletedSuccessfullyText = "Deleted Successfully";
        public const string UnableToProcessCreateRequestText = "Sever Error, Unable to Process Create Request";
        public const string UnableToProcessPutText = "Unable to Process PUT Request >> ";
        public const string DuplicateDataText = "Could not be saved because of Duplicate Data, please Retry.";
        public const string InvalidEmailAddress = "Unable to process, Invalid Email Address.";
        public const string DataFetchSuccess = "Successfully fetched data.";
        public static string InternalServerError(string param)
        {
            return "Internal Server Error, Unable to Process " + param + " Request";
        }
        public static string NullObjectError(string param)
        {
            return param + " object sent from client is null.";
        }
        public static string InvalidObjectError(string param)
        {
            return " Invalid " + param + " object sent from client.";
        }
        /// <summary>
        /// Operation update/add/delete & param=entity i.e. WebMenu/WebSubMenu/Zone etc 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="operation"></param>
        /// <returns></returns>
        public static string FailedOnSave(string operation, string param)
        {
            return operation + " " + param + " failed on save.";
        }
        public static string EntityWithIdNotFound(string param)
        {
            return " entity with id: " + param + " , hasn't been found in db.";
        }
        public static string ExistingRecord(string param)
        {
            return param + " already existing.";
        }
    }
}
