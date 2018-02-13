using Microsoft.Bot.Builder.CognitiveServices.QnAMaker;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiplomadoBotsQnAMaker.Dialogs
{
    [Serializable]
    public class QnADialog : QnAMakerDialog
    {
        public QnADialog () : base(new QnAMakerService(new QnAMakerAttribute(ConfigurationManager.AppSettings["QnASubscriptionKey"], ConfigurationManager.AppSettings["QnAKnowledgebaseId"], "No entendí la referencia :v",0.5)))
        {

        }
    }
}