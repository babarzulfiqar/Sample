using API.Common;
using API.Services;
using Microsoft.Data.SqlClient;
using System;
using System.Net;

namespace API.Helpers
{
    public static class CustomValidations
    {
        public static bool NullCheckValidation(object obj)
        {
            if (obj == null)
            {
                return true;
            }
            return false;
        }
        public static ResponseObject NullCheckResponseObject(object obj)
        {
            ResponseObject resObject;
            if (obj == null)
            {
                resObject = new ResponseObject
                {
                    MessageTitle = ConstantProps.dataNotFoundText,
                    Data = null,
                    ResponseType = ResponseObject.Type.error.ToString()
                };
                return resObject;
            }
            return null;
        }
        public static ResponseObject InvalidModelResponseObject(object data)
        {
            ResponseObject resObject = new ResponseObject
            {
                MessageTitle = ConstantProps.InvalidDataModelText,
                Data = data,
                ResponseType = ResponseObject.Type.error.ToString()
            };

            return resObject;
        }
        public static ResponseObject BadRequest(string operation, string param, object data)
        {

            ResponseObject resObject = new ResponseObject
            {
                Data = data,
                MessageTitle = ConstantProps.FailedOnSave(operation, param),
                ResponseType = ResponseObject.Type.error.ToString()
            };
            return resObject;
        }
        public static ResponseObject InternalServerResponseObject(string param)
        {

            var resObject = new ResponseObject
            {
                MessageTitle = ConstantProps.InternalServerError(param),
                ResponseType = ResponseObject.Type.error.ToString()
            };
            return resObject;
        }
        public static ResponseObject DataNotFoundResponseObject(object data)
        {
            var resObject = new ResponseObject
            {
                Data = data,
                MessageTitle = ConstantProps.dataNotFoundText,
                ResponseType = ResponseObject.Type.error.ToString()
            };
            return resObject;
        }
        public static ResponseObject DuplicateError(Exception ee)
        {
            if (ee.InnerException != null)
            {
                if (!string.IsNullOrWhiteSpace(ee.InnerException.Message))
                {
                    if (ee.InnerException is SqlException ex)
                    {
                        if (ex.Number == 2627 || ex.Number == 2601 || ex.Message.ToLower().Contains("duplicate key"))
                        {
                            var resObject = new ResponseObject
                            {
                                MessageTitle = ConstantProps.DuplicateDataText,
                                ResponseType = ResponseObject.Type.error.ToString()
                            };
                            return resObject;
                        }
                    }
                }
            }
            return null;
        }
        /// <summary>
        /// parameter=success Or Error
        /// </summary>
        /// <param name="paramter"></param>
        /// <returns></returns>
        public static ResponseObject SuccessOrErrorReponseType(string parameter, object data, string UserFriendlyMsg)
        {
            ResponseObject resObject;
            if (parameter.ToLower() == "success")
            {
                resObject = new ResponseObject()
                {
                    MessageTitle = UserFriendlyMsg,
                    Data = data,
                    ResponseType = ResponseObject.Type.success.ToString()

                };
            }
            else if (parameter.ToLower() == "error")
            {
                resObject = new ResponseObject()
                {
                    MessageTitle = UserFriendlyMsg,
                    Data = data,
                    ResponseType = ResponseObject.Type.error.ToString()

                };
            }
            else
            {
                resObject = new ResponseObject()
                {
                    MessageTitle = UserFriendlyMsg,
                    Data = data,
                    ResponseType = ResponseObject.Type.na.ToString()

                };
            }
            return resObject;
        }
    }
}
