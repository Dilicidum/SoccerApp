using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Responses
{
    public class UserResponse
    {
        public UserResponse(string UserId,string Token,DateTime timeExpired)
        {
            this.UserId = UserId;
            this.Token = Token;
            this.TimeTokenExpired = timeExpired;
        }
        public string UserId { get; set; }
        public string Token { get; set; }
        public DateTime TimeTokenExpired { get; set; }

        public UserResponse(string Token,DateTime timeExpired)
        {
            this.Token = Token;
            this.TimeTokenExpired = timeExpired;
        }
    }
}
