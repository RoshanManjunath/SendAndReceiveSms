using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Twilio.AspNet.Mvc;
using Twilio.TwiML;
using Microsoft.Extensions.Configuration;

namespace SendAndReceiveSMS.Controllers
{
    public class SMSController : TwilioController
    {
        // GET: SMS
        public ActionResult SendSms()
        {
			var accountSId = "AC254c27549e748815163b79477a5a37b1";
			var authToken = "ef9fbd038cd0dfc291862d18b3504348";
			TwilioClient.Init(accountSId, authToken);
            string resp = "Congrats!!. Successfully Sent Your SMS";

            var to = new PhoneNumber("+19173490168");
			var from = new PhoneNumber("+13476476632");

			var message = MessageResource.Create(
				to: to,
				from: from,
				body: "Hello from Roshan Hanamaraddi CS 643 Fall 2017");

            return Content(resp);
            
          
        }

		public ActionResult ReceiveSms()
		{
			var response = new MessagingResponse();
			response.Message("This is the Response message from Twilio");

			return TwiML(response);
		}
    }
}