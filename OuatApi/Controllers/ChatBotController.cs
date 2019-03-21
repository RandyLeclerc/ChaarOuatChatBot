using Business;
using Common.BTO;
using Microsoft.Bot.Connector.DirectLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace OuatApi.Controllers
{

    public class ChatBotController : ApiController
    {


        private static string directLineSecret = "z5YP2YTHZVo.0nL-8dbiFu4-M9-z7xBNOqUNTWjfDysFgdNWgsuH_7s";
        private static string botId = "qnaBotOuatHackathon";

        // This gives a name to the bot user.
        private static string fromUser = "DirectLineClientSampleUser";


        public IHttpActionResult GetAnswer(string question)
        {
            DirectLineClient client = new DirectLineClient(directLineSecret);

            var conversation = System.Web.HttpContext.Current.Session["conversation"] as Conversation;
            if (conversation == null)
            {
                conversation = client.Conversations.StartConversation();
            }

            Activity message = new Activity
            {
                From = new ChannelAccount(fromUser),
                Text = question,
                Type = ActivityTypes.Message
            };

            client.Conversations.PostActivity(conversation.ConversationId, message);

            var msg = client.Conversations.GetActivities(conversation.ConversationId);

            var msgT = from m in msg.Activities
                       where m.From.Id == botId
                       select m;

            var rep = msgT.Last().Text;

            QuestionsBTO questionsBTO = new QuestionsBTO();

            questionsBTO.question = question;
            questionsBTO.answer = rep;

            string s = "No QnA Maker answers were found. This example uses a QnA Maker Knowledge Base that focuses on smart light bulbs.\r\n                    To see QnA Maker in action, ask the bot questions like 'Why won't it turn on?' or 'I need help'.";
            if (questionsBTO.answer == s)
            {
                questionsBTO.answer = "We can't help you for the moment, contact us at info@ouat.eu for more information!";
                if (questionsBTO.status == null) questionsBTO.status = "no answer";
                var contoller = new QuestionsController();
                contoller.Post(questionsBTO);
            }

            System.Web.HttpContext.Current.Session["conversation"] = conversation;

            return Ok(questionsBTO);
        }



    }
}
