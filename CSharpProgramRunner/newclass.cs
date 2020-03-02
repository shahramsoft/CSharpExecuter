using System;
using System.Collections.Generic;

namespace Kasra
{
    public class General
    {
        public ResultViewModel Execute(int number, string name)
        {
            var lstresultValue = new List<ResultValues> 
            {
                new ResultValues
                {
                    Key="test",
                    Value="yes"
                }
            };
           
            if (number > 1)
                return new ResultViewModel
                {
                    Validate = true,
                    Message = lstresultValue
                };
            return new ResultViewModel
            {
                Validate = false,
                Message = lstresultValue
            };

        }
    }
    public class ResultViewModel
    {
        public bool Validate { get; set; }
        public object Message { get; set; }
    }
    public class ResultValues
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}

