using Microsoft.Bot.Builder.AI.QnA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OuatEchoBot.Services
{
    public interface IQnaMakerServices
    {
        QnAMaker QnAMaker { get; }

    }
}
